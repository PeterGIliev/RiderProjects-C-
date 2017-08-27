using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;

namespace OOP0016ClassBox
{
    internal class StartUp
    
    {
        public static void Main(string[] args)
        {
            Type boxType = typeof(Box);
            FieldInfo[] fields = boxType.GetFields(BindingFlags.NonPublic | BindingFlags.Instance);
            Console.WriteLine(fields.Count());

            var length = double.Parse(Console.ReadLine());
            var width = double.Parse(Console.ReadLine());
            var height = double.Parse(Console.ReadLine());

            try
            {
                var box = new Box(length, width, height);
                
                var surfaceArea = $"Surface Area - {box.SurfaceArea():F2}";
                var lateralSurface = $"Lateral Surface Area - {box.LateralSurface():F2}";
                var volume = $"Volume - {box.Volume():F2}";
                
                Console.WriteLine(surfaceArea);
                Console.WriteLine(lateralSurface);
                Console.WriteLine(volume);
            }
            catch (Exception exception)
            {
                Console.WriteLine(exception.Message);   
            }
        }
    }
}