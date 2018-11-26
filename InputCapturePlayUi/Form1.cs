
using InputCapturePlayUi.Data;
using InputCapturePlayUi.InputActionsApi;
using System;
using System.Collections.Generic;
using System.Windows.Forms;

namespace InputCapturePlayUi
{
    public partial class Form1 : Form
    {

        private IFormsInputActionFacade _dataGridInputAction;
        private IFramesToMsConverter _framesToMsConverter; 

        public Form1()
        {
            InitializeComponent();
            InitializeDataGridColumns(); 
            _dataGridInputAction = new DataGridInputAction();
            _framesToMsConverter = new FramesToMsConverter60fps(); 
        }

        private void InitializeDataGridColumns()
        {
            this.InputType.ValueType = typeof(FormsInputTypes);
            this.InputType.CellTemplate.ValueType = typeof(FormsInputTypes);
            this.InputType.DataSource = new List<FormsInputTypes>() {
                FormsInputTypes.Charge,
                FormsInputTypes.HoldDown,
                FormsInputTypes.Press,
                FormsInputTypes.Release };
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }

        /// <summary>
        /// Play button
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void button1_Click(object sender, EventArgs e)
        {
            _dataGridInputAction.LoadInput(this.dataGridView1, _framesToMsConverter);
            _dataGridInputAction.PlayInput();
        }

        private void saveInputFileToolStripMenuItem_Click(object sender, EventArgs e)
        {
            // TODO: Review how to seralize objects to json, and save it 
        }

        private void saveToolStripMenuItem_Click(object sender, EventArgs e)
        {
            // TODO: Review how to load a file with json, and serialize to object 
        }
    }
}
