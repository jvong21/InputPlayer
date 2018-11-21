﻿using InputActions.Data;
using InputActions.Data.Interface;
using InputActions.InputStrategies.Exception;
using InputActions.InputStrategies.ExternalInputApi.Interface;
using InputActions.InputStrategies.Interface;

namespace InputActions.InputStrategies.OutputToApplication
{
    public class InputToApplicationStrategyFactory : IInputStrategyFactory
    {

        private readonly IExternalInputApiWrapper ExternalInputApi;

        public InputToApplicationStrategyFactory(IExternalInputApiWrapper externalInputApi)
        {
            ExternalInputApi = externalInputApi; 
        }

        public IInputStrategy CreateInputStrategy(IInput input)
        {
            if(input is InputDown)
            {
                return new InputDownToApplicationStrategy(input, ExternalInputApi); 
            }

            if(input is InputUp)
            {
                return new InputUpToApplicationStrategy(input, ExternalInputApi); 
            }

            throw new InputStrategyNotFoundException(); 
        }
    }
}