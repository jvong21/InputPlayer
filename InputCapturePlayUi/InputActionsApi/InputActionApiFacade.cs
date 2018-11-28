using InputActions.Data;
using InputActions.Data.Interface;
using InputActions.InputCollectors.Interface;
using InputActions.InputPerformers;
using InputActions.InputStrategies.ExternalInputApi;
using InputActions.InputStrategies.ExternalInputApi.Interface;
using InputActions.InputStrategies.Interface;
using InputActions.InputStrategies.OutputToApplication;
using InputCapturePlayUi.Data;
using InputCapturePlayUi.InputActionsApi.InputCollector;
using System.Windows.Forms;

namespace InputCapturePlayUi.InputActionsApi
{
    public class DataGridInputAction: IFormsInputActionFacade
    {

        private IInputQueue _currentInputQueue; 

        public DataGridInputAction()
        {

        }
        
        public void LoadInput(DataGridView dataGridView, IFramesToMsConverter framesToMsConverter)
        {
            IInputCollector inputCollector = new DataGridInputCollector(dataGridView, framesToMsConverter);
            _currentInputQueue = inputCollector.GenerateInputs();
            
        }

        public void PlayInput()
        {
            IExternalInputApiWrapper externalInputApi = new InputSimulatorApi();
            IInputStrategyFactory inputStrategyFactory = new InputToApplicationStrategyFactory(externalInputApi);
            InputActionToApplication inputAction = new InputActionToApplication(inputStrategyFactory);
            inputAction.PeformInputs(_currentInputQueue);
        }
    }
}
