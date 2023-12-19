

namespace Records;

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
