using System;

namespace TestProjectForInterLink
{
    class Program
    {
        static void Main()
        {
            InputAndOutput input = new InputAndOutput();
            input.Message += InputAndOutput.MessageOutput;

            string pathToFile = input.InputPathToFile(); 
            string pathToNewFile = input.OutputPathtoFile();
        }
    }
}
