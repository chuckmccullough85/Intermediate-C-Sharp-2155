# Exceptions
## Overview
In this lab, we will specify boundaries on the Employee properties and behaviors 
by specifying expected exceptions.  This lab builds on the xUnit lab.
## Steps
- Add tests that expect exceptions to verify the following rules
    - An employee's first and last name must be at least 1 character in 
    length and a max of 30.  Only alpha, spaces, dash, apostrophes allowed
    - An employee's salary must be between 50 and 500 inclusive
    - An employee's hire date must be in the past
- Run the test to verify failure
- Modify *Employee* to satisfy the tests