using System.Collections;
using System.Collections.Generic;

namespace Forum.DTOModels
{
    public class PostDetailsDto
    {
        public int Id { get; set; }

        public string Title { get; set; }

        public string Content { get; set; }

        public string AuthorName { get; set; }

        public IEnumerable<ReplyDto> Replies { get; set; }

        public int ReplyCount { get; set; }
    }
}