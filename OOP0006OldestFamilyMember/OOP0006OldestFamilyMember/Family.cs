using System.Collections.Generic;
using System.IO.Pipes;
using System.Linq;

namespace OOP0006OldestFamilyMember
{
    public class Family
    {
        public List<Person> members;
        
        public void AddMember(Person member)
        {
            if (members == null)
            {
                members = new List<Person>();
                members.Add(member);
            }
            else
            {
                members.Add(member);
            }
        }

        public Person GetOldestMember()
        {
            var result = members.OrderByDescending(p => p.Age).ToList().First();
            return result;
        }
    }
    
}