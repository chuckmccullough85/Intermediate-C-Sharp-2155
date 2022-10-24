# Views
Let's create some views!

## _Layout
- open *Views/Shared/+Layout.cshtml*
    - change the default application name on the page to
    the name you chose for your application
    - change the copyright static year in the footer to
    `@DateTime.Today.Year`
    - Add links in the header for *Company* and *Employee*
```html
<li class="nav-item">
    <a class="nav-link text-dark" asp-controller="Home" asp-action="Index">Home</a></li>
<li class="nav-item">    
    <a class="nav-link text-dark" asp-controller="Company" asp-action="Index">Companies</a></li>
<li class="nav-item">
    <a class="nav-link text-dark" asp-controller="Employee" asp-action="Index">Employees</a></li>
```

## Company Views
- Add a new class to the *Controllers* folder named *CompanyController*
- Add a subdirectory of *Views* named *Company*
Initially, design the views with hard-coded data.

### Company/Index
List all companies as hyperlinks.  The hyperlink should go to ~/Company/Detail/# where # is the company id

### Company/Detail
Display a form with the company detail
The Save button should go to ~/Company/SaveDetail
The Resources button should go to ~/Company/Resources

### Company Resources 
Display 2 lists - one with employees that don't work at the company and a list of employees that do.
Display 2 buttons, hire and terminate.  They should link to Hire and Terminate actions.

### CompanyController
Define CompanyController actions to provide the navigation