using System;
using System.Windows.Forms;
using InputActions.Data;
using InputActions.Data.Interface;
using InputCapturePlayUi.Data;
using InputCapturePlayUi.InputActionsApi.InputCollector;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace InputCapturePlayUiTests
{
    [TestClass]
    public class DataGridInputCollectorTest
    {

        [TestMethod]
        public void Proper_Data_Grid_Returns_Correct_Input_Count()
        {
            DataGridView properDummyDataGrid = CreateProperDummyDataGrid();
            IFramesToMsConverter framesToMsConverter = new FramesToMsConverter60fps(); 
            DataGridInputCollector dataGridInputCollector = new DataGridInputCollector(properDummyDataGrid, framesToMsConverter);
            InputQueue inputQueue = dataGridInputCollector.GenerateInputs();
            Assert.AreEqual(inputQueue.Inputs.Count, 4); 
        }

        [TestMethod]
        public void Proper_Data_Grid_Returns_Correct_First_Input()
        {
            DataGridView properDummyDataGrid = CreateProperDummyDataGrid();
            IFramesToMsConverter framesToMsConverter = new FramesToMsConverter60fps();
            DataGridInputCollector dataGridInputCollector = new DataGridInputCollector(properDummyDataGrid, framesToMsConverter);
            InputQueue inputQueue = dataGridInputCollector.GenerateInputs();
            Input firstInput = inputQueue.Inputs.Dequeue();
            Assert.IsTrue(firstInput.InputKey.Equals("a")
                && firstInput.InputDelayInMilliseconds.Equals(16)
                && firstInput.GetType().Equals(typeof(InputHold))
                && ((InputHold)firstInput).HoldInMilliseconds.Equals(16)
                );
        }

        [TestMethod]
        public void Bad_Data_Grid_Throws_Invalid_Cast_Exception()
        {
            DataGridView badDataGrid = CreateBadDummyDataGrid();
            IFramesToMsConverter framesToMsConverter = new FramesToMsConverter60fps();
            DataGridInputCollector dataGridInputCollector = new DataGridInputCollector(badDataGrid, framesToMsConverter);
            Action generateInputDelegate = delegate () { dataGridInputCollector.GenerateInputs(); };
            Assert.ThrowsException<System.InvalidCastException>(generateInputDelegate);
           
        }

        private DataGridView CreateProperDummyDataGrid()
        {
            DataGridView properDummyDataGrid = CreateDummyDataGridView();
            Add4ProperDataRowsToDummyDataGridView(properDummyDataGrid);
            return properDummyDataGrid; 
        }

        private DataGridView CreateBadDummyDataGrid()
        {
            DataGridView properDummyDataGrid = CreateDummyDataGridView();
            AddBadDataRowToDummyDataGridViewWithOnlyStrings(properDummyDataGrid);
            return properDummyDataGrid;
        }

        private DataGridView CreateDummyDataGridView()
        {
            DataGridView dummyDataGridView = new DataGridView();
            DataGridViewColumn keyColumn = new DataGridViewTextBoxColumn();
            DataGridViewColumn inputTypeColumn = new DataGridViewComboBoxColumn();
            DataGridViewColumn delayColumn = new DataGridViewTextBoxColumn();
            DataGridViewColumn holdDurationColumn = new DataGridViewTextBoxColumn();
            dummyDataGridView.Columns.AddRange(new DataGridViewColumn[] {
            keyColumn,
            inputTypeColumn,
            delayColumn,
            holdDurationColumn});

            return dummyDataGridView; 
        }

        private void Add4ProperDataRowsToDummyDataGridView(DataGridView dummyDataGridView)
        {
            DataGridViewRow properDataRow1 = CreateProperDataGridRow("a", FormsInputTypes.Charge, 1, 1);
            DataGridViewRow properDataRow2 = CreateProperDataGridRow("b", FormsInputTypes.Press, 1, 1);
            DataGridViewRow properDataRow3 = CreateProperDataGridRow("c", FormsInputTypes.HoldDown, 1, 1);
            DataGridViewRow properDataRow4 = CreateProperDataGridRow("d", FormsInputTypes.Release, 1, 1);

            dummyDataGridView.Rows.Add(properDataRow1);
            dummyDataGridView.Rows.Add(properDataRow2);
            dummyDataGridView.Rows.Add(properDataRow3);
            dummyDataGridView.Rows.Add(properDataRow4);
        }

        private void AddBadDataRowToDummyDataGridViewWithOnlyStrings(DataGridView dummyDataGridView)
        {
            DataGridViewRow badDataRow = CreateBadDataGridRow("d", "d", "d", "d");

            dummyDataGridView.Rows.Add(badDataRow);
        }

        private DataGridViewRow CreateProperDataGridRow(string key, FormsInputTypes inputType, int delayInFrames, int hold)
        {
            DataGridViewRow dataRow = CreateGenericDataGridRowWithFourCells();
            dataRow.Cells[0].Value = key;
            dataRow.Cells[1].Value = inputType;
            dataRow.Cells[2].Value = delayInFrames;
            dataRow.Cells[3].Value = hold; 

            return dataRow; 
        }

        private DataGridViewRow CreateBadDataGridRow(string key, string inputType, string delayInFrames, string hold)
        {
            DataGridViewRow dataRow = CreateGenericDataGridRowWithFourCells(); 
            dataRow.Cells[0].Value = key;
            dataRow.Cells[1].Value = inputType;
            dataRow.Cells[2].Value = delayInFrames;
            dataRow.Cells[3].Value = hold;

            return dataRow;
        }

        private DataGridViewRow CreateGenericDataGridRowWithFourCells()
        {
            DataGridViewRow dataRow = new DataGridViewRow();
            dataRow.Cells.Add(new DataGridViewTextBoxCell());
            dataRow.Cells.Add(new DataGridViewTextBoxCell());
            dataRow.Cells.Add(new DataGridViewTextBoxCell());
            dataRow.Cells.Add(new DataGridViewTextBoxCell());

            return dataRow; 
        }
    }
}
