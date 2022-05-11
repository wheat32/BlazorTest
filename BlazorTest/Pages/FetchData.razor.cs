using Microsoft.AspNetCore.Components;
using System.Net.Http.Json;

namespace BlazorTest.Pages
{
    public partial class FetchData : ComponentBase
    {
        [Inject]
        private HttpClient Http { get; set; }

        private WeatherForecast[]? forecasts;

        protected override async Task OnInitializedAsync() => forecasts = await Http.GetFromJsonAsync<WeatherForecast[]>("sample-data/weather.json");

        public class WeatherForecast
        {
            public DateTime Date { get; set; }

            public int TemperatureC { get; set; }

            public string? Summary { get; set; }

            public int TemperatureF => 32 + (int)(TemperatureC / 0.5556);
        }
    }
}
