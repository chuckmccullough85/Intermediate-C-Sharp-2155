## Overview
Add the service and db context to the dependency injection container.

| | |
| --------- | --------------------------- |
| Exercise Folder | DI |
| Builds On | Models |
 Time to complete | 30 minutes

In this lab, we will add the service and db context to the dependency injection container and complete the company pages for the web application.

Currently, the service creates a dbcontext and the controller creates the service.  This is not a good practice.  We will use dependency injection to create the dbcontext and service and inject them into the controller. The DI container will manage the lifetime of the dbcontext and service.

### Dependency Injection
1. Add the service and db context to the dependency injection container.
    1. Open the Program.cs file.
    1. Add the following before the call to Build().
    ```csharp
    builder.Services.AddDbContext<PayDbContext>();
    builder.Services.AddScoped<IPayrollService, PayrollService>();
    ```
Both methods allow configuration of the service. For instance, we can pass in the connection string for the db context.  This is beyond the scope of this lab.

### Payroll Service
1. Remove the code that creates the **new** dbcontext.
1. Add a constructor to the PayrollService class that takes a dbcontext as a parameter. 
1. Assign it to the private field.

### Compsny Controller
1. Remove the code that creates the **new** service.
1. Add a constructor to the CompanyController class that takes an IPayrollService as a parameter.

Run and test the application.  It should work the same as before.

### Manage Resources  (optional)
First, we need to add a model to support this view.  .Net has a class to support list boxes named *SelectListItem*.

#### ManageResourcesModel

1. Add a new class in the models folder named *ManageResourcesModel* (you can add this to the existing *CompanyModel* file if you want).
1. Add these properties:
    1. int CompanyId
    1. string CompanyName
    1. IEnumerable<SelectListItem> EmployedList
    1. IEnumerable<SelectListItem> UnEmployedList
    1. string SelectedEmployedId
    1. string SelectedUnEmployedId
1. Add a default constructor and initialize the properties (this constructor will only be used by ASP.Net on form sumission).
1. Add a constructor that takes the company id, name, and lists of *IdNamePair*s for the employed and un-employed employees.
1. Use LinQ to convert the *IdNamePair*s to *SelectListItem*s.

*Example*
```csharp
public class ManageResourcesModel
{
    public ManageResourcesModel()
    {
        EmployedList = new List<SelectListItem>();
        UnEmployedList = new List<SelectListItem>();
        CompanyName = "";
    }
    public ManageResourcesModel(int companyId, string companyName, 
        IEnumerable<IdNamePair> employedList, IEnumerable<IdNamePair> unemployedList)
    {
        CompanyId = companyId;
        CompanyName = companyName;
        EmployedList = employedList.Select(x => new SelectListItem { Value = x.Id.ToString(), Text = x.Name });
        UnEmployedList = unemployedList.Select(x => new SelectListItem { Value = x.Id.ToString(), Text = x.Name });
    }
    public int CompanyId { get; set; }
    public string? CompanyName { get; set; }
    public string? SelectedEmployedId { get; set; } = "";
    public string? SelectedUnEmployedId { get; set; } = "";
    public IEnumerable<SelectListItem>? EmployedList { get; set; }
    public IEnumerable<SelectListItem>? UnEmployedList { get; set; }
}
```

#### ManageResources View
For the view, we will declare the model type and bind the controls to the model.  In our solution, we also use boostrap to style the page.

The Hire/Terminate buttons change from hyperlinks to submit buttons.  Tney need to add the company id to the URL.  This is done via `asp-route-id'= "@Model.CompanyId")`

*Example*
```html
@model ManageResourcesModel
@{
    ViewBag.Title = "Manage Resources";
}
<h1>Manage Resources for @Model.CompanyName</h1>

<form asp-controller="Company">
    <div class="container-fluid">
        <div class="row">
            <div class="col-5">
                <div>
                    <label>Available Resources</label>
                    <select 
                        asp-items="@Model.UnEmployedList" asp-for="SelectedUnEmployedId" 
                        class="form-select" size="10">
                    </select>
                </div>
            </div>
            <div class="col-2">
                <input type="submit" asp-action="hire" asp-route-id="@Model.CompanyId" value="Hire" />
                <input type="submit" asp-action="terminate" asp-route-id="@Model.CompanyId" value="Terminate" />
            </div>
            <div class="col-5">
                <label>Employed Resources</label>
                <select asp-items="@Model.EmployedList" asp-for="SelectedEmployedId" 
                        class="form-select" size="10">
                </select>
            </div>
        </div>
    </div>
</form>
```

#### Company Controller
1. Modify the *ManageResources* action to build a model and pass it to the view.  Note that we needed to add the company id as an argument to the action.  The *Detail* page had to be updated to include the id in the URL.
1. Add the *hire* and *terminate* actions.  
1. The *hire* action will call the service to hire the employee and redirect to the *ManageResources* action.
1. The *terminate* action will call the service to terminate the employee and redirect to the *ManageResources* action.
    1. Note that to pass the id into the action, we add it as an anonymouse object to the redirect method.

*Our Solution*
```csharp
public IActionResult ManageResources(int id)
{
    var emps = svc.GetEmployees(id);
    var nonemps = svc.GetNonEmployees(id);
    var model = new ManageResourcesModel(id, svc.GetCompanyName(id), emps, nonemps);
    return View(model);
}
public IActionResult Hire(int id, int selectedUnEmployedId)
{
    svc.Hire(selectedUnEmployedId, id);
    return RedirectToAction("ManageResources", new {id});
}
public IActionResult Terminate(int id, int selectedEmployedId)
{
    svc.Terminate(selectedEmployedId, id);
    return RedirectToAction("ManageResources", new {id});
}
```

#### Payroll Service
First, we added a read-only *Name* property to *Payable* and added *HumanResource* DbSet to the db context.  This gives us access to all the employees/contractors/etc... in the database.


The *GetEmployees* and *GetNonEmployees* methods are very similar.  They both use LinQ to get the list of employees and convert them to *IdNamePair*s.

*Example*
```csharp
public IEnumerable<IdNamePair> GetEmployees(int id)
{
    return ctx.Companies.Find(id)?.Resources.Select(e => new IdNamePair(e.Id, e.Name)).ToList() ?? new List<IdNamePair>();
}

public IEnumerable<IdNamePair> GetNonEmployees(int id)
{
    var emps = GetEmployees(id);
    var all = ctx.Resources.Select(e => new IdNamePair(e.Id, e.Name)).ToList();
    return all.Except(emps);
}
```

The *Hire* and *Terminate* methods are also very similar.  They both use the *Find* method to get the company and employee.  The *Hire* method adds the employee to the company's resources and the *Terminate* method removes the employee from the company's resources.

*Example*
```csharp
public void Hire(int empId, int companyId)
{
    var c = ctx.Companies.Find(companyId);
    if (c == null) throw new Exception("Company not found");
    Payable? emp = ctx.Resources.Find(empId);
    if (emp != null)
        c.Resources.Add(emp);
    ctx.SaveChanges();
}

public void Terminate(int empId, int companyId)
{
    var c = ctx.Companies.Find(companyId);
    if (c == null) throw new Exception("Company not found");
    var emp = c.Resources.FirstOrDefault(e => e.Id == empId);
    if (emp != null)
        c.Resources.Remove(emp);
    ctx.SaveChanges();
}
```

This process continues with possibly different developers creating (in parallel) the employee pages, controllers and services.  The team will need to adjust the properties and design to suppor the new requirements.
