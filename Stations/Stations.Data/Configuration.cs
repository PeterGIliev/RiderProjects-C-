namespace Stations.Data
{
    public class Configuration
    {
        public const string ConnectionString =
            @"Server=localhost;Database=Stations ;User ID=sa;Password=Peter@76545759";
        
        //This has to be deleted. It is only used so that Rider on Mac migrates the database!
        public static void Main(string[] args)
        {
            
        }
    }
}