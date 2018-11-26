using InputCapturePlayUi.Data;
using System.Windows.Forms;

namespace InputCapturePlayUi.InputActionsApi
{
    interface IFormsInputActionFacade
    {
        void LoadInput(DataGridView dataGridView, IFramesToMsConverter framesToMsConverter);
        void PlayInput(); 
    }
}
