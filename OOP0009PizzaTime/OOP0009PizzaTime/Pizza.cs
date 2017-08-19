using System.Collections.Generic;

namespace OOP0009PizzaTime
{
    public class Pizza
    {
        public static SortedDictionary<int, List<string>> pizzaByGroups 
            = new SortedDictionary<int, List<string>>();

        public string name;
        public int group;

        public Pizza(params string [] pizzaParams)
        {
            
        }

        public SortedDictionary<int, string> GroupName => this.groupName;


    }
}