## Overview
In this lab, we demonstrate string literals.

| | |
| --------- | --------------------------- |
| Exercise Folder | LiteralStrings |
| Builds On | [FirstLab](../FirstLab) |
| Time to complete | 10 minutes

---

1. Override ***ToString*** in the *Employee* class
    1. start typing ***override*** and select ***ToString*** from the list
1. Return a formatted string containing all important employee information.
1. Use an interpolated literal string
1. In the *Main* method (or top-level code), you can demonstrate **ToString** by calling it explicitly or by simply passing an employee to **Console.WriteLine**.

*For Example:*
```csharp
Employee e = new("Hank", "Hill", 200, DateTime.Today);
Console.WriteLine(e);  // implicit call to ToString
```




