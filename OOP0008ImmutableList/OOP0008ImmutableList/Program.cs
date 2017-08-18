using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;

namespace OOP0008ImmutableList
{
    internal class Program
    {
        public static void Main(string[] args)
        {
//            ImmutableList list = new ImmutableList();
            
            Type immutableList = typeof(ImmutableList);
            FieldInfo[] fields = immutableList.GetFields();
            if(fields.Length < 1)
            {
                throw new Exception();
            }
            else
            {
                Console.WriteLine(fields.Length);
            }

            MethodInfo[] methods = immutableList.GetMethods();
            bool containsMethod = methods.Any(m => m.ReturnType.Name.Equals("ImmutableList"));
            if(!containsMethod)
            {
                throw new Exception();
            }
            else
            {
                Console.WriteLine(methods[0].ReturnType.Name);
            }
        }
    }
}