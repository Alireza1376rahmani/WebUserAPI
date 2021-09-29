using System.Collections.Generic;

namespace WebUserAPI.Controllers
{
    public interface IWeatherService
    {
        IEnumerable<WeatherForecast> GetAll();
    }
}