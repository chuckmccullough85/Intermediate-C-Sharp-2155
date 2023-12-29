## Overview
This lab demonstrates the **record** type specifier.

| | |
| --------- | --------------------------- |
| Exercise Folder | Records |
| Builds On | [Tuple](../tuple) |
| Time to complete | 10 minutes

### Steps

Building on the *Tuples* lab, define a single record type to use for the result of each temperature conversion function.

1. Define a record type named ```Temperature``` with three properties: ```Fahrenheit```, ```Celsius```, and ```Kelvin```.  Each property should be of type ```double```.  See below.
1. Modify the ```From*``` methods to return a ```Temperature``` record instead of a tuple.
1. Modify the ```Main``` method to use the new ```Temperature``` record type.
1. Demonstrate deconstruction as well as ```Temperature``` variables.


```public record Temperature(double Fahrenheit, double Celsius, double Kelvin);```

