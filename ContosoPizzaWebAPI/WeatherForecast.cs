namespace ContosoPizzaWebAPI;

public class WeatherForecast
{
    public DateOnly Date { get; set; }

    public int TemperatureC { get; set; }

    public int TemperatureF => 32 + (int)(TemperatureC / 0.5556);

    public int test3 { get; set; }
    public string test23 { get; set; }
}
