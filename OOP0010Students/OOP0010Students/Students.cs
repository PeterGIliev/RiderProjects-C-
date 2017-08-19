namespace OOP0010Students
{
    public class Students
    {
        private string name;
        public static int counter;

        public Students(string name)
        {
            counter++;
            this.name = name;
        }

        static Students()
        {
            counter = 0;
        }

        public string Name => this.name;
    }
}