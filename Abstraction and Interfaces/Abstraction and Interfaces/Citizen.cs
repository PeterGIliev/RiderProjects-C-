namespace AbstractionandInterfaces
{
    public class Citizen : IPerson, IResident
    {
        public Citizen(string name, int age, string country)
        {
            Name = name;
            Age = age;
            Country = country;
        }
        public string Name { get; }
        public int Age { get; }
        public string Country { get; }

        public void IResident.GetName(string name)
        {
            throw new System.NotImplementedException();
        }
        
        public void IPerson.GetName(string name)
        {
            throw new System.NotImplementedException();
        }
    }
}