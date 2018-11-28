using InputActions.Data;
using InputActions.Data.Interface;
using InputActions.InputCollectors.Interface;
using InputCapturePlayUi.Data;
using System;
using System.Collections.Generic;
using System.Windows.Forms;

namespace InputCapturePlayUi.InputActionsApi.InputCollector
{
    public class DataGridInputCollector : IInputCollector
    {

        private DataGridView _currentDataGridView;
        private InputTypeToInputActionTypeFactory _inputFactory;
        private IFramesToMsConverter _framesToMsConverter;

        public DataGridInputCollector(DataGridView dataGridView, IFramesToMsConverter framesToMsConverter)
        {
            _currentDataGridView = dataGridView;
            _framesToMsConverter = framesToMsConverter;
            _inputFactory = new InputTypeToInputActionTypeFactory();
        }

        public IInputQueue GenerateInputs()
        {
            IInputQueue finalInputQueue = GenerateInputQueue();
            return finalInputQueue; 
        }

        private IInputQueue GenerateInputQueue()
        {
            IInputQueue generatedInputQueue = new InputQueue();

            for (int rowNumber = 0; 
                rowNumber < _currentDataGridView.Rows.Count - 1; // Last row is always empty 
                rowNumber++)
            {
                var row = _currentDataGridView.Rows[rowNumber];

                Input currentInput = GenerateInputFromRow(row);
                generatedInputQueue.Enqueue(currentInput);
            }

            return generatedInputQueue; 
        }

        private Input GenerateInputFromRow(DataGridViewRow row)
        {
            var keyCell = row.Cells[0];
            var inputTypeCell = row.Cells[1];
            var delayCell = row.Cells[2];
            var holdCell = row.Cells[3];

            string key = keyCell.Value.ToString();

            FormsInputTypes inputType= (FormsInputTypes)inputTypeCell.Value; 

            int delayInFrames = delayCell.Value != null ? Int32.Parse(delayCell.Value.ToString()) : 0;
            int delay = _framesToMsConverter.ConvertFramesToMs(delayInFrames); 

            int holdInFrames = holdCell.Value != null ? Int32.Parse(holdCell.Value.ToString()) : 0;
            int hold = _framesToMsConverter.ConvertFramesToMs(holdInFrames); 

            Input currentInput = _inputFactory.CreateInputFromFormsInputType(
                inputType, 
                key, 
                delay,
                hold); 

            return currentInput; 
        }
    }
}
