using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Runtime.InteropServices;

namespace L002SetsAndDictionaries
{
    public class APerformanceMeasurement
    {
        public static void main(string[] args)
        {
            var watch = Stopwatch.StartNew();

            var testList1 = new List<int>();

            for (int i = 0; i < 1000000; i++)
            {
                testList1.Add(i);
            }
            
            watch.Stop();

            Console.WriteLine(watch.ElapsedMilliseconds);
            Console.WriteLine(watch.ElapsedTicks);
            
            
            watch = Stopwatch.StartNew();

            var testList2 = new HashSet<int>();

            for (int i = 0; i < 1000000; i++)
            {
                testList2.Add(i);
            }
            
            watch.Stop();

            Console.WriteLine(watch.ElapsedMilliseconds);
            Console.WriteLine(watch.ElapsedTicks);
        }
    }
}