## Overview
In this lab, we will replace our *GenericArrayList*
with a standard library class.


| | |
| --------- | --------------------------- |
| Exercise Folder | Collections |
| Builds On | [ExtensionMethods](../ExtensionMethods) |
 Time to complete | 30 minutes


### Part 1
- Delete the source file *GenericArrayList*.  Good riddance!
- Replace the class in *Company* with *List*
- Change the *Pay* method to utilize **Linq**

### Part 2
New requirement - we want to prevent duplicate hires
- Create a new test to specify that if the same employee is hired more than once, only one will be hired
	- do this for the same object (reference) and for different, equal employees
	- note - we don't need to test .Net collections, but we do want to 
	specify that the payables are compatible with hash sets and sorted sets


