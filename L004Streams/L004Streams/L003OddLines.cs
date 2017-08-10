using System;
using System.Collections.Generic;
using System.IO;

namespace L004Streams
{
    public class L003OddLines
    {
        public static void Main(string[] args)
        {
            var linesCollection = new List<string>();
            
            using (StreamReader reader = new StreamReader("01_OddLinesIn.txt"))
            {
                string line = reader.ReadLine();
                linesCollection.Add(line);
                
                while (line != null)
                {
                    line = reader.ReadLine();
                    linesCollection.Add(line);
                }
            }

            using (StreamWriter writer = new StreamWriter("../01_OddLinesOut.txt"))
            {
                for (int i = 0; i < linesCollection.Count; i++)
                {
                    if (i % 2 != 0)
                    {
                        writer.WriteLine(linesCollection[i]);
                    }
                }
            }
        }
    }
}