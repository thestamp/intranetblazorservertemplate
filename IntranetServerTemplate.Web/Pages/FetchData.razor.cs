using IntranetServerTemplate.Core.Services;
using Microsoft.AspNetCore.Components;


namespace IntranetServerTemplate.Web.Pages
{
    public class FetchDataBase: ComponentBase
    {
        [Inject] WeatherForecastService ForecastService { get; set; }

        protected WeatherForecastService.WeatherForecastModel[]? forecasts;

        protected override async Task OnInitializedAsync()
        {
            forecasts = await ForecastService.GetForecastAsync(DateTime.Now);
        }
    }
}
