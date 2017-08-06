using System;
using System.IO;

namespace L004Streams
{
    public class ReadFromFile
    {
        public static void Main(string[] args)
        {
            using (StreamReader reader = new StreamReader("TestFile.txt"))
            {
                int lineNumber = 0;
                string line = reader.ReadLine();
                while (line != null)
                {
                    lineNumber++;
                    Console.WriteLine("Line {0}:{1}", lineNumber, line);
                    line = reader.ReadLine();
                }
            }
        }
    }
}