## Overview
Create strongly typed models with validation attributes.

| | |
| --------- | --------------------------- |
| Exercise Folder | Models |
| Builds On | FormSubmit |
 Time to complete | 30 minutes

 From the previous exercise, you might have had some typos or at least had to be careful in naming your form fields and ViewBag properties.  In this exercise, you will create a strongly typed model and use it in your view.  You will also add validation attributes to your model properties.

 ---

## Add a Model
1. In `CompanyController.Index`, pass the `IdNamePair` list to the view as a strong model.  Change the view to use the model.
1. In the Models folder, add a new class named `CompanyModel`.  Change the class to a **record** and add these properties
    1. Id
    1. Name
    1. Taxid
    1. Address
1. In `CompanyController.Detail` create a new instance of `CompanyModel` and pass it to the view.  
1. Change the view to use the model. Use asp-for to bind the model properties to the form fields.
    1. Add <span asp-validation-for="Name"></span> to the Name field.
1. Modify `CompanyController.SaveDetail` to accept a `CompanyModel` parameter.  Use the model to update the company in the database.
    1. Don't forget to check the validation status of the model
1. Run the application and test it out.  You should be able to save a company and see the validation errors.

## Client-Side Validation
1. Open _Layout.cshtml.
1. Browse to *wwwroot/lib/jquery-validation* and find the minified version of the jQuery validation library.
    1. drag int into *_Layout* below the jQuery script tag.
1. Repeat for the unobtrusive validation library.

Test the application again.  You should see client-side validation errors.