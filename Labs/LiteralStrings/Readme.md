# Literal Strings
## Overview
In this lab, we demonstrate string literals.

| | |
| --------- | --------------------------- |
| Exercise Folder | LiteralStrings |
| Builds On | [FirstLab](../FirstLab) |
| Time to complete | 10 minutes

---

1. Override ***ToString*** in the *Employee* class
1. Return a formatted string containing all important employee information.
1. Use an interpolated literal string


<details>
<summary>Need a hint?</summary>

```csharp
public override string ToString()
{
    return $"""
        An Employee, {LastName}, {FirstName} with a Salary of {Salary:c}
        has made {YtdGrossPay:c}.  {FirstName} was hired on {HireDate:D}
        """;
}
```

</details>