## Overview
In this lab, we will define an attribute and create a tool that extracts information from assemblies

| | |
| --------- | --------------------------- |
| Exercise Folder | Reflection |
| Builds On | None |
| Time to complete | 30 minutes

1. Create a new Console Applicaton named *Reflection* (or add this project to your solution)

### Documenter
- Create a new class named AuthorAttribute - inherits from Attribute
    - Define a constructor parameter accepting a string argument
---
- Create a class named *AuthorDocumentor*.  This class will scan the current assembly for classes attributed with the [Author] attribute.
- Using the reflection API, find attributed classes and display the name of the class and the author.

Here is a hint of the documentor class:

```csharp
public class AuthorDocumenter
{

    public void Scan()
    {
        var assembly = Assembly.GetExecutingAssembly();
        var types = assembly.GetTypes()
            .Where(t => t.IsDefined(typeof(AuthorAttribute)));
        foreach (var t in types)
        {
        ...
```

### Attributed Classes 

- Create and mark some classes with the [Author] attribute

Run the documenter and see the results!
