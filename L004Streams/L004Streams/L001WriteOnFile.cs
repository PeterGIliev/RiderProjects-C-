using System.IO;

namespace L004Streams
{
    public class L001WriteOnFile
    {
        public static void main(string[] args)
        {
            StreamWriter writer = new StreamWriter("TestFile.txt");

            for (int i = 0; i < 10; i++)
            {
                writer.WriteLine($"Number is: {i}");
            }
            
            writer.Close();
        }
    }
}