## Overview
In this lab, add deconstructors to the *Employee* class.

| | |
| --------- | --------------------------- |
| Exercise Folder | Deconstruction |
| Builds On | [Literal Strings](../LiteralStrings) |
| Time to complete | 30 minutes


### Steps

1. Add the following deconstructors to the *Employee* class.

```csharp
public void Deconstruct (out string FullName, out double Salary, 
                        out double YtdGross )
public void Deconstruct(out string FirstName, out string LastName, 
            out double Salary, 
            out double YtdGross, out DateTime HireDate)
```

2. Update *Program.cs* to verify the deconstructors

---
