using System.Collections.Generic;
using System.Linq;

namespace OOP0014OldestFamilyMember
{
    public class Family
    {
        private List<Person> people;

        public Family()
        {
            this.people = new List<Person>();
            this.people = people;
        }
        
        public List<Person> People => people;

        public void AddMember(Person member)
        {
         this.people.Add(member);   
        }

        public Person GetOldestMember()
        {
            var result = people.OrderByDescending(p => p.Age).ToList()[0];
            return result;
        }
        
    }
}