using System;
using System.Collections.Generic;
//using System.Linq;
//
//namespace L002SetsAndDictionaries
//{
//    public class X012HandsOfCards
//    {
//        public static void main(string[] args)
//        {
//            var input = Console.ReadLine();
//            var calc = new Dictionary<string, HashSet<string>>();
//            var result = new Dictionary<string, int>();
//
//            while (input != "JOKER")
//            {
//
//                var list = input
//                    .Split(new[] {':', ','}, StringSplitOptions.RemoveEmptyEntries)
//                    .ToList();
//
//                var name = list[0];
//
//                for (int i = 1; i < list.Count; i++)
//                {
//                    calc[name].Add(list[i].Trim());
//                }
//            }
//            var counter = 0;
//
//            foreach (var item in calc.Values)
//            {
//
//                foreach (var subitem in item)
//                {
//                   
//                    var type = subitem.Substring(subitem.Length - 1);
//                    var newsubitem = subitem.Remove(subitem.Length - 1);
//                    var power = newsubitem;
//                    var typen = 0;
//                    var powern = 0;
//
//                    switch (type)
//                    {
//                        case "S":
//                            typen = 4;
//                            break;
//                        case "H":
//                            typen = 3;
//                            break;
//                        case "D":
//                            typen = 2;
//                            break;
//                        case "C":
//                            typen = 1;
//                            break;
//                    }
//
//                    switch (power)
//                    {
//                        case "2":
//                            powern = 2;
//                            break;
//                        case "3":
//                            powern = 3;
//                            break;
//                        case "4":
//                            powern = 4;
//                            break;
//                        case "5":
//                            powern = 5;
//                            break;
//                        case "6":
//                            powern = 6;
//                            break;
//                        case "7":
//                            powern = 7;
//                            break;
//                        case "8":
//                            powern = 8;
//                            break;
//                        case "9":
//                            powern = 9;
//                            break;
//                        case "10":
//                            powern = 10;
//                            break;
//                        case "J":
//                            powern = 11;
//                            break;
//                        case "Q":
//                            powern = 12;
//                            break;
//                        case "K":
//                            powern = 13;
//                            break;
//                        case "A":
//                            powern = 14;
//                            break;
//                    }
//
//                    counter += typen * powern;

//                    if (!final.ContainsKey(name))
//                    {
//                        final.Add(name, counter);
//                    }
//                    else
//                    {
//                        final[name] += counter;
//                    }
//
//                }
//
//
//
//
//                input = Console.ReadLine();
//            }
//
//            foreach (var item in final)
//            {
//                Console.WriteLine($"{item.Key}: {item.Value}");
//            }

//        }
//    }
//}