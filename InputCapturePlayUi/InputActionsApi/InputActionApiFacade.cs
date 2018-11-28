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

        public IInputQueue LoadedInputQueue
        {
            get {

                if (_currentInputQueue.Count <= 0)
                {
                    return new InputQueue();
                }

                return _currentInputQueue;
            }
        }

        public void LoadInput(DataGridView dataGridView, IFramesToMsConverter framesToMsConverter)
        {
            IInputCollector inputCollector = new DataGridInputCollector(dataGridView, framesToMsConverter);
            _currentInputQueue = inputCollector.GenerateInputs();
            
        }

        public void LoadInputFromQueueToGrid(IInputQueue inputQueue, DataGridView dataGridView, IFramesToMsConverter framesToMsConverter)
        {
            _currentInputQueue = inputQueue;
            Input currentInput;
            while (inputQueue.Count > 0)
            {
                currentInput = inputQueue.Dequeue();

                DataGridViewRow dataRow = CreateDataGridViewRow();

                FormsInputTypes inputType = GetInputType(currentInput); 

                dataRow.Cells[0].Value = currentInput.InputKey;
                dataRow.Cells[1].Value = inputType;
                dataRow.Cells[2].Value = framesToMsConverter.ConvertMsToFrames(currentInput.InputDelayInMilliseconds);
                dataRow.Cells[3].Value = inputType.Equals(FormsInputTypes.Charge) ?
                    framesToMsConverter.ConvertMsToFrames(((InputHold)currentInput).HoldInMilliseconds).ToString()
                    : null;

                dataGridView.Rows.Add(dataRow); 
            }
        }

        private DataGridViewRow CreateDataGridViewRow()
        {
            DataGridViewRow dataRow = new DataGridViewRow();
            dataRow.Cells.Add(new DataGridViewTextBoxCell());
            dataRow.Cells.Add(new DataGridViewTextBoxCell());
            dataRow.Cells.Add(new DataGridViewTextBoxCell());
            dataRow.Cells.Add(new DataGridViewTextBoxCell());

            return dataRow; 
        }

        private FormsInputTypes GetInputType(Input input)
        {
            if (input is InputDown)
            {
                return FormsInputTypes.HoldDown;
            }
            else if (input is InputUp)
            {
                return FormsInputTypes.Release;
            }
            else if (input is InputPress)
            {
                return FormsInputTypes.Press;
            }
            return FormsInputTypes.Charge;
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
