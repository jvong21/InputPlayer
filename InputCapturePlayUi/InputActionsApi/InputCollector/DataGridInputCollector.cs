using InputActions.Data;
using InputActions.Data.Interface;
using InputActions.InputCollectors.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace InputCapturePlayUi.InputActionsApi.InputCollector
{
    public class DataGridInputCollector : IInputCollector
    {

        private DataGridView CurrentDataGridView; 

        public DataGridInputCollector(DataGridView dataGridView)
        {
            CurrentDataGridView = dataGridView; 
        }

        public InputQueue GenerateInputs()
        {
            // TODO: Create a unit test for this object and method
            Queue<Input> generatedInputQueue = GenerateInputQueue(); 
            InputQueue finalInputQueue = new InputQueue(generatedInputQueue);
            return finalInputQueue; 
        }

        private Queue<Input> GenerateInputQueue()
        {
            Queue<Input> generatedInputQueue = new Queue<Input>();

            for (int rowNumber = 0; 
                rowNumber < CurrentDataGridView.Rows.Count - 1; // Last row is always empty 
                rowNumber++)
            {
                var row = CurrentDataGridView.Rows[rowNumber];

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
            string inputType = inputTypeCell.Value.ToString();
            int delay = Int32.Parse(delayCell.Value.ToString());
            

            Input currentInput;

            // TODO: Create a proper factory for generating inputs from datagridview. Standardize the inputType
            switch (inputType.ToLower())
            {
                case "press":
                    currentInput = new InputPress(key, delay);
                    break;
                case "hold":
                    int hold = Int32.Parse(holdCell.Value.ToString());
                    currentInput = InputHold.CreateInputHoldWithHoldInMilliseconds(key, delay, hold);
                    break;
                case "down":
                    currentInput = new InputDown(key, delay);
                    break;
                default:
                    currentInput = new InputUp(key, delay);
                    break;
            }

            return currentInput; 
        }
    }
}
