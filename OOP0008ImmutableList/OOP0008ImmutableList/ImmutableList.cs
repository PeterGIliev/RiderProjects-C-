using System.Collections;
using System.Collections.Generic;

namespace OOP0008ImmutableList
{
    public class ImmutableList
    {
        private List<int> collection;

        public ImmutableList(List<int> collection)
        {
            this.collection = new List<int>();
        }
        
        public List<int> Collection => collection;

        public ImmutableList AddElement(int element)
        {
            return null;
        }
    }
}