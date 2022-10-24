# Inheritance
In this lab, we will expand the types of people that can be hired, including
contractors and interns.
## Builds On - Moqlab

## Overview
- Define new classes
    - *Contractor* - contractors make a fixed rate X 50 hours
    - *Intern* - interns are always paid a stipend of $50
    - *HumanResource* - the base class for contractors, interns, and employees
- Define tests for the new classes
- Update Company to contain *Human Resource* objects

## Steps
1. Create new classes, *HumanResource, Company, Intern*
1. Change *Employee* to inherit from *HumanResource*
1. Pull up from *Employee* to *HumanResource* the common fields and properties
    - first and last name
    - Hiredate
    - YtdGrossPay
1. Define *Pay* as a abstract method in *HumanResource*
1. Define a constructor in *HumanResource* taking first and last name as parameters
1. Fix up Employee class
1. Change *Contractor* and *Intern* to inherit from *HumanResource*
1. Re-run unit tests - company and employee tests should still succeed
1. Create new classes *ContractorTest & InternTest*
    - implement tests to specify *Pay* results
    - verify new tests fail
    - implement *Intern & Contractor* so that tests pass
1. Update *CompanyTest* to mock *HumanResource* rather than *IEmployee*
1. Update *Company* to contain *HumanResource* objects

