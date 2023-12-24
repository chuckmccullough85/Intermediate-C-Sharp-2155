## Overview
Use Razor to generate the page data dynamically!

| | |
| --------- | --------------------------- |
| Exercise Folder | DynamicViews |
| Builds On | Views |
 Time to complete | 30 minutes

### Service Interface
To build the list of companies, we need to know the name of the company and the id of the company.

Since we have a database, let's also start designing the service interface for the web application to use.  Remember, *interfaces* are designed by the *caller*!

- In your payroll project (*EfPayroll*) add a new interface named `IPayrollService`
- In the same file, add a new **record** named `IdNamePair` with two properties: `Id` and `Name`.  This will be used to return the list of companies.

### Company Controller
- In `CompanyController`, add a field for `IPayrollService`.
- In `Index`, use the service to get a list of companies by calling `svx.GetAllCompanies(  )`.  Use the VS helper to generate the method in the interface. You might need to tweak the method signature a bit. `IEnumerable<IdNamePair> GetCompanies();`
- Pass the list of companies to the view using `ViewBag` or `ViewData`.

### Company Index View
- In the view, use a `foreach` loop to generate the list of companies.
    - Note - you will need to use a qualified name for the `IdNamePair` type.  This is because the view is in a different namespace.  You can also add a `@using` to the view or add a `@using` to the `_ViewImports.cshtml` file.

### Payroll Service
- In the `EFPayroll` project, add a new class named `PayrollService` that implements `IPayrollService`.
- Create a new `PayDbContext` and store it in a field (inline).
- Implement the `GetCompanies` method by returning a list of `IdNamePair` objects.  Always `ToList()` the results of a query before returning them from a service method.

- FInally, create an instance of this class to initialize the field in `CompanyController`.

Now you should be able to run the application and see the list of companies.