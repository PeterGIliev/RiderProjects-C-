using Forum.Data.Models;
using Forum;

namespace Forum.Data

{
    public class AddData
    {
        //Method fills up the database with information
        public static void Seed(ForumDbContext context)
        {
            var users = new[]
            {
                new User("gosho", "123"), 
                new User("pesho", "123"), 
                new User("ivan", "123"), 
                new User("merry", "123")
            };
            
            context.Users.AddRange(users);

            var categories = new[]
            {
                new Category("C#"), 
                new Category("Support"), 
                new Category("Python"), 
                new Category("EF Core") 
            };
            
            context.Categories.AddRange(categories);

            var posts = new[]
            {
                new Post("C# Rulz", "Thrue", categories[0], users[0]),
                new Post("Python Rulz", "Thrue again", categories[2], users[1]),
                new Post("Broken Software", "Reset", categories[1], users[2])
            };
            
            context.Posts.AddRange(posts);

            var replies = new[]
            {
                new Reply("Turn it on", posts[2], users[0]),
                new Reply("Sure", posts[0], users[2]),
                new Reply("Sure", posts[0], users[2]),
            };
            
            context.Replies.AddRange(replies);
            
            context.SaveChanges();
        }
    }
}