using KeyPress.KeyActions.Data;

namespace KeyPress.KeyActions
{
    interface IKeyStrokeWriter
    {
        void WriteKeys(KeyStroke[] keyStrokes);
    }
}
