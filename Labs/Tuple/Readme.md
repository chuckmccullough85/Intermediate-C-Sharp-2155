# Tuples

## Overview
This independent lab demonstrates various tuple features.

## Instructions

- Create a new console project (in your current solution).
    -  Name the project *TuplesLab*
- Create a public static class named *TemperatureConverter*
- Add these functions
    - FromCelcius(double val)
    - FromFahrenheit(double val)
    - FromKelvin
- Each function should return a tuple containing the values of the other temperature scales.
For instance, *FromCelcius* should return the F&deg; and K&deg; values
- In *Program.cs* demonstrate each function with several examples
- Show both deconstructed values and the inbuilt tuple *ToString* method
---
### Formulas

```
To get K from C, add 273.15 to the C value
To get F from C, F = (C x 9/5) + 32
To get C from F, C = (F-32) X 5/9
```

