## Overview
This independent lab demonstrates various tuple features.

| | |
| --------- | --------------------------- |
| Exercise Folder | Tuple |
| Builds On | None |
| Time to complete | 30 minutes

---
## Instructions

1. Create a new console project (in your current solution), or add this Tuple.csproj to your solution.
    -  Name the project *Tuple*
1. Create a public static class named *TemperatureConverter*
1. Add these functions
    - FromCelcius(double val)
    - FromFahrenheit(double val)
    - FromKelvin
1. Each function should return a tuple containing the values of the other temperature scales.
For instance, *FromCelcius* should return the F&deg; and K&deg; values
1. In *Program.cs* demonstrate each function with several examples
1. Show both deconstructed values and the inbuilt tuple *ToString* method
---
### Formulas

```
To get K from C, add 273.15 to the C value
To get F from C, F = (C x 9/5) + 32
To get C from F, C = (F-32) X 5/9
```

