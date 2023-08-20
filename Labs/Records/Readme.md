## Overview
This lab demonstrates the **record** type specifier.

| | |
| --------- | --------------------------- |
| Exercise Folder | Records |
| Builds On | Tuple |
| Time to complete | 10 minutes

Building on the *Tuples* lab, define a single record type to use for the 
result of each temperature conversion function.

:::spoiler
*Program.cs*
```c#
using Records;
using static Records.TemperatureConverter;

var r = FromCelcius(0);
Console.WriteLine(r.ToString());
r = FromCelcius(100);
Console.WriteLine(r.ToString());

var (k, c, f) = FromKelvin(399);
Console.WriteLine($"{k} {f} {c}");

Temperature t = FromFahrenheit(99);
Console.WriteLine($"{t.F}F is {t.C}c and {t.K}k");
```

*TemperatureConverter.cs*
```c#
namespace Records
{
    public record Temperature(double K, double C, double F);
    public static class TemperatureConverter
    {
        public static Temperature FromCelcius(double val)
        {
            var f = val * 9.0 / 5.0 + 32;
            var k = val + 273.15;
            return new(k, val, f);
        }
        public static Temperature FromFahrenheit(double val)
        {
            var c = (val-32) * 5.0 / 9.0;
            var k = c + 273.15;
            return new (k, c, val);
        }
        public static Temperature FromKelvin(double val)
        {
            var c = val - 273.15;
            var f = c * 9 / 5 + 32;
            return new (val, c, f);
        }
    }
}

```