## Overview
Create a controller method to process a form submission.

| | |
| --------- | --------------------------- |
| Exercise Folder | FormSubmit |
| Builds On | DynamicViews |
 Time to complete | 30 minutes

## Exercise Details

The detail form has fields for name, address and tax Id.  However, our `Company` class does not have an address field.  We will need to add it and add methods to our service to support getting and saving company details.

1. Add an address property to the `Company` class.  It should be a `string` and be called `Address`.
1. Run the db test method again to create a new database with the new field.
1. Add a parameter to `CompanyController.Detail` named id.  This will be the id of the company we are editing.
1. In `CompanyController.Detail`, call `svc.GetCompanyDetail` and pass the company id.  This method will return a tuple containing the id, name, address and tax id of the company.  Assign that to `ViewBag` properties (use individual properties rather than assigning the tuple to avoid losing the property names.  Remember deconstruction?)
1. Add the method to the service interface and class.
1. In `CompanyController.SaveDetail`, add parameters for id, name, address and tax id.
1. Call `svc.SaveCompanyDetail` and pass the parameters.
    1. Add the method to the service interface and class.
1. In `Detail.cshtml`, initialize the form fields with the values from the `ViewBag`.
    1. Add id to the URL route in the form tag.
1. Verify that the form field names match the parameter names in `CompanyController.SaveDetail`.
1. Currently,  `SaveDetail` returns the *Index* view.  Now, index requires a model of id/names.  Change the return to `RedirectToAction("Index")`.  This also keeps the browser URL in sync with the page being displayed.
1. Run and test!