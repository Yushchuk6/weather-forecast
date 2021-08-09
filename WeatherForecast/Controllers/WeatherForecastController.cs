using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using System;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Json;
using System.Threading.Tasks;
using WeatherForecast.Models;

namespace WeatherForecast.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class WeatherForecastController : ControllerBase
    {
        private readonly HttpClient _client = new HttpClient();
        private readonly IConfiguration _config;
        private readonly string _apiKey;

        public WeatherForecastController(IConfiguration config)
        {
            _config = config;
            if (_client.BaseAddress == null)
            {
                _client.BaseAddress = new Uri(_config["OpenWeatherMap:ConnectionUrl"]);
                _apiKey = _config["OpenWeatherMap:ServiceApiKey"];
            }
        }

        [HttpGet]
        public async Task<IActionResult> GetAsync(string city)
        {
            // making request to OpenWeatherMap
            var respWeather = await _client.GetAsync($"weather?q={city}&units=metric&appid={_apiKey}"); 
            var respForecast = await _client.GetAsync($"forecast?q={city}&units=metric&appid={_apiKey}");

            // checking if requests are successful
            if (!respWeather.IsSuccessStatusCode)
            {
                return StatusCode(((int)respWeather.StatusCode), await respWeather.Content.ReadFromJsonAsync<ErrorModel>());
            }
            else if (!respForecast.IsSuccessStatusCode)
            {
                return StatusCode(((int)respForecast.StatusCode), await respForecast.Content.ReadFromJsonAsync<ErrorModel>());
            }
            else
            {
                // unpaking content into models
                var contentWeather = await respWeather.Content.ReadFromJsonAsync<WeatherModel>();
                var contentForecast = await respForecast.Content.ReadFromJsonAsync<WeatherForecastModel>();

                // selecting useful data in convenient format
                var resWeather = new WeatherModel[] { contentWeather };
                var resForecast = contentForecast.List.Where((_, ind) => ind % 8 == 7).ToArray();

                // compining two results into one: first element - current weather, next elements - forecasts
                var result = resWeather.Concat(resForecast).ToArray();
                return Ok(result);
            }
        }
    }
}
