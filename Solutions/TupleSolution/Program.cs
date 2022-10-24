using static Tuples.TemperatureConverter;

var r = FromCelcius(0);
Console.WriteLine(r.ToString());
r = FromCelcius(100);
Console.WriteLine(r.ToString());

var (f, c) = FromKelvin(399);
Console.WriteLine($"{f} {c}");

double kelv, cels;
(cels, kelv) = FromFahrenheit(99);
Console.WriteLine($"99F is {cels}c and {kelv}k");


