namespace WeatherForecast.Models
{
    public class WeatherForecastModel
    {
        public WeatherModel[] List { get; set; }
    }
    public class WeatherModel
    {
        public int Dt { get; set; }
        public Main Main { get; set; }
        public Weather[] Weather { get; set; }
    }

    public class Main
    {
        public float Temp { get; set; }
        public float Feels_like { get; set; }
        public int Pressure { get; set; }
        public int Humidity { get; set; }
    }

    public class Weather
    {
        public string Main { get; set; }
        public string Description { get; set; }
        public string Icon { get; set; }
    }
}
