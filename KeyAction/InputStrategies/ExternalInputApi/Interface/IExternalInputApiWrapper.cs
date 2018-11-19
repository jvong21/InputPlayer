

namespace InputActions.InputStrategies.ExternalInputApi.Interface
{
    public interface IExternalInputApiWrapper
    {
        void Keyboard_KeyDown(string key);


        void Keyboard_KeyUp(string key);


        void Keyboard_KeyPress(string key);
    }
}
