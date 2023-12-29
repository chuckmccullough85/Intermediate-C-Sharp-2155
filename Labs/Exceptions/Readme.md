## Overview
In this lab, we will specify boundaries on the Employee properties and behaviors 
by specifying expected exceptions.  This lab builds on the xUnit lab.

| | |
| --------- | --------------------------- |
| Exercise Folder | Exceptions |
| Builds On | [xUnitIntro](../xUnitIntro) |
| Time to complete | 30 minutes

---

## Steps
1. Add tests that expect exceptions to verify the following rules
    - An employee's first and last name must be at least 1 character in 
    length and a max of 30.  Only alpha, spaces, dash, apostrophes allowed
    - An employee's salary must be between 50 and 500 inclusive
    - An employee's hire date must be in the past
1. Run the test to verify failure
1. Modify *Employee* to satisfy the tests

---

In the test methods, we can use a traditional try/catch block to verify that the exception is thrown.  For instance, in the code below, if the code gets to the Assert.True line, then the exception was not thrown.  If any other exception besides ***ArgumentOutOfRangeException*** is thrown, then the test will fail because the exception will not be caught.

```csharp
[Fact]
public void TestEmployeeBadSalary2() 
{
    try {
        new Employee("Hank", "Hill", -50, DateTime.Today);
        Assert.True(false, "Should have thrown an exception");
    }
    catch (ArgumentOutOfRangeException)
    {
    }
}
```

### Alternative using Assert.Throws

The xUnit framework provides a more elegant way to test for exceptions.  The Assert.Throws method takes a delegate (a method that takes no parameters and returns nothing) and verifies that the exception is thrown.  If the exception is not thrown, then the test fails.  If any other exception besides the one specified is thrown, then the test fails.

```csharp
private void createbad() { new Employee("Hank", "$$", 200, DateTime.Today); }

[Fact]
public void TestEmployeeBadLastName()
{
    Assert.Throws<ArgumentException>(createbad);
}
```

This code is often implemented using a Lambda expression instead of a separate method.  We will discuss Lambda expressions in a later lab.



