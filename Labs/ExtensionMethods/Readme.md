# Extension Methods
In this lab, we create an extension to the string class.

| | |
| --------- | --------------------------- |
| Exercise Folder | ExtensionMethods |
| Builds On | Interfaces |
 Time to complete | 30 minutes

## Overview
The **Java** string class has a cool method named **Matches**
This method takes a regular expression as a parameter and returns a true
if the string matches the expression and false if it doesn't.

Let's take that a step further and add a method to the string class
to *Validate* a string with a regular expression.

Add a class to the *Interfaces* project named *Extensions*.  Change the
class to ` public static `
Define a static bool extension method named *Validate*.  The first **this** argument
is a string (extending string class) and the second is a regular expression.
If the string doesn't start with a ^ and/or end with a $, add them.
Return true if this string matches the regex or false if it doesn't

Update the validation methods in *HumanResource* to use the extension method.

