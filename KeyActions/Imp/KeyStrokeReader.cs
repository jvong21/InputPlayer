using KeyPress.KeyActions.Data;
using System;
using System.Text;

namespace KeyPress.KeyActions.Imp
{
    class KeyStrokeReader : IKeyStrokeReader
    {
        protected KeyStroke[] KeyStrokes; 

        public KeyStrokeReader()
        {
            InitializeKeyStrokesCollection(0);
        }

        public KeyStroke[] GetKeyStrokes()
        {
            return KeyStrokes; 
        }

        public void ReadKeys()
        {
            string inputString = ReadString(); 
            string trimmedString = RemoveSpaces(inputString);
            BuildKeyStrokeCollection(trimmedString);
        }

        private string ReadString()
        {
            Console.WriteLine("---Input a string---");
            string input = Console.ReadLine();
            return input; 
        }

        private string RemoveSpaces(string input)
        {
            StringBuilder finalStringBuilder = new StringBuilder();
            string[] splitString = input.Split(' '); 
            foreach(string split in splitString)
            {
                finalStringBuilder.Append(split); 
            }
            string finalString= finalStringBuilder.ToString();
            return finalString.Trim(); 
        }

        private void BuildKeyStrokeCollection(string input)
        {
            try
            {
                InitializeKeyStrokesCollection(input.Length);
                for (int i = 0; i < input.Length; i++)
                {
                    KeyStrokes[i] = new KeyStroke(input.Substring(i, 1)); 
                }
            }
            catch (Exception e)
            {
                throw new Exception("Error adding keys to keystroke collection.",e);
            }
        }

        private void InitializeKeyStrokesCollection(int keyStrokesLength)
        {
            KeyStrokes = new KeyStroke[keyStrokesLength];
        }

    }
}
