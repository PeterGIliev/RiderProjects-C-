using System.Collections.Generic;

namespace Forum.Data.Models
{
    public class Post
    {
        public Post()
        {
        }

        public Post(string title, string content, Category category, User author)
        {
            this.Title = title;
            this.Content = content;
            this.Category = category;
            this.Author = author;
        }

        public Post(string title, string content, User author, Category category)
        {
            this.Title = title;
            this.Content = content;
            this.Category = category;
            this.Author = author;
        }

        public Post(string title, string content, int authorId, int categoryId)
        {
            Title = title;
            Content = content;
            CategoryId = categoryId;
            AuthorId = authorId;
        }


        public int Id { get; set; }

        public string Title { get; set; }

        public string Content { get; set; }

        public int AuthorId { get; set; }
        public User Author { get; set; }
        
        public int CategoryId { get; set; }
        public Category Category { get; set; }

        public ICollection<Reply> Replies { get; set; } = new List<Reply>();
        
        public ICollection<PostTag> PostTags { get; set; } = new List<PostTag>();
    }
}