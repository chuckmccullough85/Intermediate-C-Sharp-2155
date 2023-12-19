

namespace Tuples;

public static class TemperatureConverter
{
    public static (double F, double K) FromCelcius(double val)
    {
        var f = val * 9.0 / 5.0 + 32;
        var k = val + 273.15;
        return (f, k);
    }
    public static (double C, double K) FromFahrenheit(double val)
    {
        var c = (val-32) * 5.0 / 9.0;
        var k = c + 273.15;
        return (c, k);
    }
    public static (double F, double C) FromKelvin(double val)
    {
        var c = val - 273.15;
        var f = c * 9 / 5 + 32;
        return (f, c);
    }


}
