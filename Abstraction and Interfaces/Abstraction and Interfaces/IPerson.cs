namespace AbstractionandInterfaces
{
    public interface IPerson
    {
        string Name { get; }
        
        int Age { get; }

        void GetName();
    }
}