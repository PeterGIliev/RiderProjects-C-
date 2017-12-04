using System;
using System.Linq;
using AutoMapper;
using Forum.Data;
using Forum.Data.Models;
using Forum.DTOModels;
using Microsoft.EntityFrameworkCore;
using AutoMapper.QueryableExtensions;

namespace Forum
{
    public class StartUp
    {
        public static void Main(string[] args)
        {
            var context = new ForumDbContext();
            
            //Reset.ResetDatabsa(context);
            
           // AddData.Seed(context);

//            var categories = context.Categories
//                .Include(c => c.Posts)
//                .ThenInclude(p => p.Author);
//
//            foreach (var cat in categories)
//            {
//                Console.WriteLine($"{cat.Name} {cat.Posts.Count}");
//
//                foreach (var pst in cat.Posts)
//                {
//                    Console.WriteLine($"--{pst.Title} {pst.Content}");
//                    Console.WriteLine($"-- by {pst.Author.Username}");
//
//                    foreach (var rep in pst.Replies)
//                    {
//                        Console.WriteLine($"----{rep.Content} from {rep.Author.Username}");
//                    }
//                }
//            }  

//            -----------------
            
            InitializeAutoMapper();
            
            var post = context.Posts.FirstOrDefault(p => p.Id == 1);
            var replies = context.Replies.Where(p => p.Id == 1 
                                                  || p.Id == 2).ToList();

            var postDto = Mapper.Map<PostDetailsDto>(post);

            Console.WriteLine();
        }

        private static void InitializeAutoMapper()
        {
            Mapper.Initialize(cfg =>
            {
                cfg.CreateMap<Post, PostDetailsDto>()
                    .ForMember(dto => dto.ReplyCount,
                        opt => opt.MapFrom(src =>
                            src.Replies.Sum(p => p.Id)));
                
                cfg.CreateMap<Reply, ReplyDto>();
            });
        }
    }
}