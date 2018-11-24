using InputActions.Data;
using InputActions.InputCollectors.Interface;
using InputActions.InputPerformers;
using InputActions.InputStrategies.ExternalInputApi;
using InputActions.InputStrategies.ExternalInputApi.Interface;
using InputActions.InputStrategies.Interface;
using InputActions.InputStrategies.OutputToApplication;
using InputCapturePlayUi.InputActionsApi.InputCollector;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace InputCapturePlayUi
{
    public partial class Form1 : Form
    {
        

        public Form1()
        {
            InitializeComponent();
             
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
            // TODO: Abstract this whole process to a different object so the form logic can be separate from using the InputAction API
            // TODO: Create validation for the data grid values before they get collected
            //// TODO: Make sure the column inputs are limited to types only 
            //// TODO: Lock the Input Type column to only allow Hold, Press, KeyUp, or KeyDown 
            IInputCollector inputCollector = new DataGridInputCollector(this.dataGridView1);
            InputQueue currentInputQueue = inputCollector.GenerateInputs();
            IExternalInputApiWrapper externalInputApi = new InputSimulatorApi();
            IInputStrategyFactory inputStrategyFactory = new InputToApplicationStrategyFactory(externalInputApi);
            InputActionToApplication inputAction = new InputActionToApplication(inputStrategyFactory);
            inputAction.PeformInputs(currentInputQueue);
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void button3_Click(object sender, EventArgs e)
        {

        }
    }
}
