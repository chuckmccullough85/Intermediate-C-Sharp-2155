# Attributes & Reflection
In this lab, we will define an attribute and create a tool that extracts information from assemblies

## Creates a new Console Application

### Documenter
- Create a new class named AuthorAttribute - inherits from Attribute
    - Define a constructor parameter accepting a string argument
---
 - Create a console application named *Documentor*
 - Create a class named *AuthorDocumentor* that loads the an assembly 
 and searches for classes attributed with the [Author] attribute.
 - Display the name of the class and the author

Here is a hint of the documentor class:

```c#
public class AuthorDocumenter
{
    public AuthorDocumenter(string assemblyPath)
    {
        AssemblyPath = assemblyPath;
    }

    public string AssemblyPath { get; set; }

    public void Scan()
    {
        var assembly = System.Runtime
            .Loader
            .AssemblyLoadContext.Default
            .LoadFromAssemblyPath(AssemblyPath);
        var types = assembly.GetTypes()
            .Where(t => t.IsDefined(typeof(AuthorAttribute)));
        foreach (var t in types)
        {
        ...
```

## Previous lab
- In a previous lab, add the *Documenter* project as a dependency
- Mark some classes with the [Author] attribute

Run the documenter, passing the assembly name of the project containing attributes.
