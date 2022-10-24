# Deconstruction
## Overview
This lab builds on *FirstLab*.  
In this lab, add deconstructors to the *Employee* class.
## Steps
- Add the following deconstructors to the *Employee* class.

```cs
public void Deconstruct (out string FullName, out double Salary, 
                        out double YtdGross )
public void Deconstruct(out string FirstName, out string LastName, 
            out double Salary, 
            out double YtdGross, out DateTime HireDate)
```
- Update *Program.cs* to verify the deconstructors