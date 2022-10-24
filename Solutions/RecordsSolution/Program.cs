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

