using KeyPress.KeyActions.Data;
using System;
using System.Windows.Forms;

namespace KeyPress.KeyActions.Imp
{
    class KeyStrokeWriter : IKeyStrokeWriter
    {
        public void WriteKeys(KeyStroke[] keyStrokes)
        {
            Console.Write("Writing string: ");
            foreach(KeyStroke key in keyStrokes)
            {
                SendKeys.SendWait(key.Key);
            }
            SendKeys.SendWait("{ENTER}");
            string consoleread = Console.ReadLine(); 
        }


    }
}
