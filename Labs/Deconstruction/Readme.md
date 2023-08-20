## Overview
In this lab, add deconstructors to the *Employee* class.

| | |
| --------- | --------------------------- |
| Exercise Folder | Deconstruction |
| Builds On | LiteralStrings |
| Time to complete | 30 minutes


### Steps
1. Add the following deconstructors to the *Employee* class.

```c#
public void Deconstruct (out string FullName, out double Salary, 
                        out double YtdGross )
public void Deconstruct(out string FirstName, out string LastName, 
            out double Salary, 
            out double YtdGross, out DateTime HireDate)
```
2. Update *Program.cs* to verify the deconstructors

---
:::spoiler
*In Employee*
```c#
public void Deconstruct (out string FullName, out double Salary, out double YtdGross )
{
    FullName = $"{FirstName} {LastName}";
    Salary = this.Salary;
    YtdGross = this.YtdGrossPay;
}
public void Deconstruct(out string FirstName, out string LastName, out double Salary, 
    out double YtdGross, out DateTime HireDate)
{
    FirstName = this.FirstName;
    LastName = this.LastName;
    Salary = this.Salary;
    YtdGross = this.YtdGrossPay;
    HireDate = this.HireDate;
}
```

*Main...*
```c#
Employee e = new("Hank", "Hill", 200, DateTime.Today);

e.Pay();
e.Pay();

var (n, s, y) = e;
Console.WriteLine($"{n}'s salary is {s:c} and has made {y:c} so far");

var (f, l, _, _, hired) = e;
Console.WriteLine($"{f} {l} was hired on {hired}");
```
:::

---
