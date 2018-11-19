using KeyPress.KeyActions.Data;

namespace KeyPress.KeyActions
{
    interface IKeyStrokeReader
    {
        void ReadKeys();
        KeyStroke[] GetKeyStrokes(); 
    }
}
