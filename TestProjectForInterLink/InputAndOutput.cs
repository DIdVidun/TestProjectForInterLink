using System;
using System.Collections.Generic;
using System.IO;
using System.Text;


namespace TestProjectForInterLink
{
    public class InputAndOutput
    {
        public event EventHandler<MessageEventArgs> Message;

        public string InputPathToFile()
        {
            string pathToFile = "";
            bool IsPathToFileCorrected = false;

            while (IsPathToFileCorrected == false)
            {
                try
                {
                    pathToFile = CheckInputPathToFile();
                    IsPathToFileCorrected = true;
                }
                catch (FileNotFoundException e)
                {
                    Message?.Invoke(this, new MessageEventArgs(e.Message));
                }
            }

            return pathToFile;
        }

        public static string CheckInputPathToFile()
        {
            Console.Write("Enter the path to file: ");

            var pathToFile = Console.ReadLine();

            if (!File.Exists(pathToFile))
                throw new FileNotFoundException();

            return pathToFile;
        }

        public string OutputPathtoFile()
        {
            string pathToFile = "";
            bool IsPathToNewFileCorrected = false;

            while (IsPathToNewFileCorrected == false)
            {
                try
                {
                    pathToFile = CheckOutputPathtoFile();
                    IsPathToNewFileCorrected = true;
                }
                catch (Exception e)
                {
                    Message?.Invoke(this, new MessageEventArgs(e.Message));
                }
            }

            return pathToFile;
        }

        public string CheckOutputPathtoFile()
        {
            Console.Write("Enter the path to create reformated file: ");

            var pathToNewFile = Console.ReadLine();

            if ((pathToNewFile == null) || (pathToNewFile.IndexOfAny(Path.GetInvalidPathChars()) != -1))
                throw new Exception();

            FileStream ReformatedFile = new FileStream($"{pathToNewFile}" + @"\ReformatedFile.csv", FileMode.Create);
            ReformatedFile.Close();

            return pathToNewFile;
        }

        public class MessageEventArgs : EventArgs
        {
            public string Message { get; private set; }

            public MessageEventArgs(string message)
            {
                Message = message;
            }
        }

        public static void MessageOutput(object sender, InputAndOutput.MessageEventArgs e)
        {
            Console.Write(e.Message);
        }

        public static void WriteLineInFile(List<string> list, FileStream ReformatedFile)
        {
            string info = string.Join(", ", list);
            byte[] binfo = Encoding.Default.GetBytes(info);
            ReformatedFile.WriteAsync(binfo, 0, binfo.Length);
        }
    }
}
