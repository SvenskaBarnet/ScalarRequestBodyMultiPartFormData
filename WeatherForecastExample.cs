using Swashbuckle.AspNetCore.Filters;

namespace ScalarRequestBodyMultipartFormData;
public class WeatherForecastExample : IExamplesProvider<WeatherForecast>
{
    public WeatherForecast GetExamples()
    {
        return new WeatherForecast
        {
            Date = new DateOnly(2021, 01, 01),
            TemperatureC = 25,
            Summary = "Hot"
        };
    }
}