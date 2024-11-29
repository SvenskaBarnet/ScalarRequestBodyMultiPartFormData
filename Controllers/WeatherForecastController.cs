using Microsoft.AspNetCore.Mvc;
using Swashbuckle.AspNetCore.Filters;

namespace ScalarRequestBodyMultipartFormData.Controllers;

[ApiController]
[Route("[controller]")]
public class WeatherForecastController : ControllerBase
{
    [HttpPost("Example/body")]
    [Consumes("multipart/form-data")]
    [SwaggerRequestExample(typeof(WeatherForecast), typeof(WeatherForecastExample))]
    public WeatherForecast Post([FromForm] WeatherForecast weatherForecast)
    {
        return weatherForecast;
    }
    
}