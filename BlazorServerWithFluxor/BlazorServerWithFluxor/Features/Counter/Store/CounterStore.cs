using Fluxor;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BlazorServerWithFluxor.Features.Counter.Store
{
    public record CounterState
    {
        public int CurrentCounte { get; init; }
    }

    public class CounterFeature : Feature<CounterState>
    {
        public override string GetName() => "Counter";

        protected override CounterState GetInitialState()
        {
            return new CounterState
            {
                CurrentCounte = 0
            };
        }
    }

    public class CounterIncrementAction { }

    public static class CounterReducers
    {
        [ReducerMethod(typeof(CounterIncrementAction))]
        public static CounterState OnIncrement(CounterState state)
        {
            return state with
            {
                CurrentCounte = state.CurrentCounte + 1
            };
        }
    }
}
