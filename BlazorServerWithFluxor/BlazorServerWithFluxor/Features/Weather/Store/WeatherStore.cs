using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Fluxor;
using BlazorServerWithFluxor.Data;

namespace BlazorServerWithFluxor.Features.Weather.Store
{
    public record WeatherState
    {
        public bool Initialized { get; init; }
        public bool Loading { get; init; }
        public WeatherForecast[] Forecasts { get; init; }
    }

    public class WeatherFeature : Feature<WeatherState>
    {
        public override string GetName() => "Weather";

        protected override WeatherState GetInitialState()
        {
            return new WeatherState
            {
                Initialized = false,
                Loading = false,
                Forecasts = Array.Empty<WeatherForecast>()
            };
        }
    }

    

    

    public static class WeatherReducers
    {
        [ReducerMethod]
        public static WeatherState OnSetForecasts(WeatherState state, WeatherSetForecastsAction action)
        {
            return state with
            {
                Forecasts = action.Forecasts,
                Loading = false
            };
        }

        [ReducerMethod(typeof(WeatherSetInitializedAction))]
        public static WeatherState OnSetInitialized(WeatherState state)
        {
            return state with
            {
                Initialized = true
            };
        }

        [ReducerMethod(typeof(WeatherLoadForecastAction))]
        public static WeatherState OnLoadForecast(WeatherState state)
        {
            return state with
            {
                Loading = true
            };
        }        
    }

    public class WeatherEffects
    {
        private readonly WeatherForecastService _weatherForecastService;

        public WeatherEffects(WeatherForecastService weatherForecastService)
        {
            _weatherForecastService = weatherForecastService;
        }

        [EffectMethod(typeof(WeatherLoadForecastAction))]
        public async Task LoadForecasts(IDispatcher dispatcher)
        {
            var forecasts = await _weatherForecastService.GetForecastAsync(DateTime.Now);
            dispatcher.Dispatch(new WeatherSetForecastsAction(forecasts));
        }
    }

    public class WeatherSetInitializedAction { }
    public class WeatherLoadForecastAction { }
    public class WeatherSetForecastsAction
    {
        public WeatherForecast[] Forecasts { get; }

        public WeatherSetForecastsAction(WeatherForecast[] forecasts)
        {
            Forecasts = forecasts;
        }
    }
}
