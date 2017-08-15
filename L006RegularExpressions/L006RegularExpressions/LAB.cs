using System;
using System.IO;
using System.Runtime.InteropServices.ComTypes;
using System.Text.RegularExpressions;

namespace L006RegularExpressions
{
    public class LAB
    {
        public static void main(string[] args)
        {
            var pattern =
                    @"(?<CourseName>[A-Z][A-Za-z+#]*)_(?<CourseInstance>[JFMASOND][a-z]{2}_[\d]{3}[4567])\s+(?<Username>[A-Z][a-z]{1,3}\d{2}_\d{2,4})\s+(?<Score>[\d]{1,2}[100]*)";

            var rgx = new Regex(pattern);
            string[] allInputLines = File.ReadAllLines("dataNew.txt");

//            if (!string.IsNullOrEmpty(allInputLines[line]) && rgx.IsMatch(allInputLines[line]))
//            {
//                
//            }
        }
    }
}