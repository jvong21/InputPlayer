﻿using InputActions.Data.Interface;
using InputActions.InputStrategies.ExternalInputApi.Interface;
using System.Threading;

namespace InputActions.InputStrategies.OutputToApplication
{
    public class InputUpToApplicationStrategy : InputToApplicationStrategy
    {
        public InputUpToApplicationStrategy(Input input, IExternalInputApiWrapper externalInputApi): base(input, externalInputApi)
        {
        }

        protected override void PerformInput_Internal()
        {
            Thread.Sleep(Input.InputDelayInMilliseconds);
            InputSimulator.Keyboard_KeyUp(Input.InputKey);
        }
    }
}
