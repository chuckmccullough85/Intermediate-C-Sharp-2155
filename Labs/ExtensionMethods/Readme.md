## Overview
In this lab, we create an extension to the string class.

| | |
| --------- | --------------------------- |
| Exercise Folder | ExtensionMethods |
| Builds On | [Interfaces](../Interfaces) |
 Time to complete | 30 minutes

## Requirements
The **Java** string class has a cool method named **Matches**
This method takes a regular expression as a parameter and returns a true if the string matches the expression and false if it doesn't.

Let's take that a step further and add a method to the string class to *Validate* a string with a regular expression.

### Steps

- Add a class to the *Interfaces* project named *Extensions*.  Change the class to ` public static `
- Add these methods to the class:

```csharp
public static bool IsValid (this string text, string expression)
public static void Validate<E>(this string text, string expression, string error="invalid") where E : Exception, new()
public static void Validate(this string text, string expression, string error = "invalid")
```

- The first method, `IsValid` should return true if the string matches the expression and false if it doesn't.
- The second method, `Validate` should throw an exception of type `E` if the string does not match the expression.  The exception should have the message passed in as the `error` parameter.  This method can call the first method to do the actual validation.
- The third method, `Validate` should throw an exception of type `ArgumentException` if the string does not match the expression.  The exception should have the message passed in as the `error` parameter.  This method can call the second method.

