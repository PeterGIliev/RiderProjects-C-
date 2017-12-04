using Microsoft.EntityFrameworkCore;

namespace Forum.Data
{
    public class Reset
    {
        public static void ResetDatabsa(ForumDbContext context)
        {
            //Method deleates database
            context.Database.EnsureDeleted();
            
            //Method creates database and does all migrations that follow.
            context.Database.Migrate(); 
        }
    }
}