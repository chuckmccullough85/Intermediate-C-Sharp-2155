## Overview
In this code exercise, you will convert a regular class into a generic.

| | |
| --------- | --------------------------- |
| Exercise Folder | Generics |
| Builds On | None |
| Time to complete | 20 minutes


## Steps

1. Add Generics.csproj to your current solution
    1. Right-click on the solution in the Solution Explorer and select *Add > Existing Project*
1. Run the unit tests - they all should succeed
1. Review the code for the class ObjectArrayList .
1. Change the name of the class to GenericArrayList
1. Convert the class to a generic by lifting the object type from the class, replacing with a generic parameter
1. Update the test class to utilize the generic
1. Re-run tests