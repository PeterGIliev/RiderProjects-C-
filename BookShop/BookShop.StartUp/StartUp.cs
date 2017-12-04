using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using AutoMapper;
using AutoMapper.QueryableExtensions;
using BookShop.Dto;
using BookShop.Models;

namespace BookShop
{
    using BookShop.Data;
    using BookShop.Initializer;
    
    public class StartUp
    {
        static void Main()
        {
            using (var db = new BookShopContext())
            {
//                DbInitializer.ResetDatabase(db);
                
                //Before using the collecten to be manipulated, it has to be initialize
                //and materialize as shown bellow!
                var books = db.Books.ToArray();
                 
                Mapper.Initialize(cfg => cfg.CreateMap<Author, AuthorDto>()
                .ForMember(dto => dto.BookNumber,
                           opt => opt.MapFrom(src =>
                               src.Books.Count)));
                
                
                
                var author = db.Authors.ToArray();
                //var productDto = Mapper.Map <AuthorDto>(author);
                var authors = Mapper.Map<Author [], List<AuthorDto>>(author);
                //Console.WriteLine($"{productDto.FirstName} {productDto.LastName} {productDto.BookNumber}");

//                foreach (var aut in author)
//                {
//                    Console.WriteLine($"{aut.FirstName} {aut.LastName}");
//
//                    foreach (var book in aut.Books)
//                    {
//                        Console.WriteLine($"  --{book.Title}");
//                    }
//                }

                var bookDtos = db.Books.ProjectTo<BookDto>().ToList();
                
                //List<BookDto> bookDtos = Mapper.Map<List<Book>, List<BookDto>> (boooks);

                foreach (var bd in bookDtos)
                {
                    Console.WriteLine(bd.Title);
                }
            }
        }

        public static string GetBooksByAgeRestriction(BookShopContext context, string command)
        {
            int commandnumber = -1; //chek this out
            switch (command.ToLower())
            {
                    case "minor":
                        commandnumber = 0;
                        break;
                        
                    case "teen":
                        commandnumber = 1;
                        break;
                        
                    case "adult":
                        commandnumber = 2;
                        break;
            }

            var collection = context.Books
                .Where(b => b.AgeRestriction == (AgeRestriction) commandnumber)
                .Select(b => b.Title)
                .OrderBy(b => b)
                .ToList();

            var result = new StringBuilder("");

            foreach (var book in collection)
            {

                result.Append($"{book}");
                result.Append(Environment.NewLine);
            }
            
            return result.ToString();
        }
        
        public static string GetGoldenBooks(BookShopContext context)
        {
            
            var collection = context.Books
                .Where(b => b.EditionType == EditionType.Gold && b.Copies < 5000)
                .ToList()
                .OrderBy(b => b.BookId);

            var result = new StringBuilder("");

            foreach (var book in collection)
            {

                result.Append($"{book.Title}");
                result.Append(Environment.NewLine);
            }
            
            return result.ToString();
        }

        public static string GetBooksByPrice(BookShopContext context)
        {
            var collection = context.Books
                .Where(b => b.Price > 40)
                .ToList()
                .OrderByDescending(b => b.Price);

            var result = new StringBuilder();

            foreach (var book in collection)
            {
                result.Append($"{book.Title} - ${book.Price:F2}");
                result.Append(Environment.NewLine);
            }
            
            return result.ToString();
        }

        public static string GetBooksNotRealeasedIn(BookShopContext context, int year)
        {
            var collection = context.Books
                .Where(b => b.ReleaseDate.Value.Year != year)
                .ToList()
                .OrderBy(b => b.Title);

            var result = new StringBuilder();

            foreach (var book in collection)
            {
                result.Append($"{book.Title}");
                result.Append(Environment.NewLine);
            }
            
            return result.ToString();
        }

        public static string GetBooksByCategory(BookShopContext context, string input)
        {
            var categories = input.ToLower().Split(new[] {" ", "\t", Environment.NewLine}, StringSplitOptions.RemoveEmptyEntries)
                .ToList();
            
            var collection = context.Books
                .Where(b => b.BookCategories.Any(c => categories.Contains(c.Category.Name.ToLower())))
                .Select(c => c.Title)
                .ToList()
                .OrderBy(c => c);

            var result = new StringBuilder();

            foreach (var book in collection)
            {
                result.Append($"{book}");
                result.Append(Environment.NewLine);
            }
            
            return result.ToString();
        }

        public static string GetBooksReleasedBefore(BookShopContext context, string date)
        {
            var collection = context.Books
                .Where(b => b.ReleaseDate.Value < DateTime.ParseExact(date, "dd-MM-yyyy", new DateTimeFormatInfo()))
                .ToList()
                .Select(b => new
                {
                    b.Title,
                    b.EditionType,
                    b.Price,
                    b.ReleaseDate
                })
                .OrderByDescending(b => b.ReleaseDate);

            var result = new StringBuilder();

            foreach (var book in collection)
            {
                result.Append($"{book.Title} - {book.EditionType} - ${book.Price:F2}");
                result.Append(Environment.NewLine);
            }
            
            return result.ToString();
        }

        public static string GetAuthorNamesEndingIn(BookShopContext context, string input)
        {
            var collection = context.Books
                .Where(b => b.Author.FirstName.EndsWith(input))
                .Select(b => new
                {
                    b.Author.FirstName,
                    b.Author.LastName
                })
                .ToHashSet()
                .OrderBy(b => b.FirstName)
                .ThenBy(b => b.LastName);

            var result = new StringBuilder();

            foreach (var book in collection)
            {
                result.Append($"{book.FirstName} {book.LastName}");
                result.Append(Environment.NewLine);
            }
            
            return result.ToString();
        }

        public static string GetBookTitlesContaining(BookShopContext context, string input)
        {
            var collection = context.Books
                .Where(b => b.Title.ToLower().Contains(input.ToLower()))
                .Select(b => new
                {
                    b.Title
                })
                .ToList()
                .OrderBy(b => b.Title);

            var result = new StringBuilder();

            foreach (var book in collection)
            {
                result.Append($"{book.Title}");
                result.Append(Environment.NewLine);
            }
            
            return result.ToString();
        }

        public static string GetBooksByAuthor(BookShopContext context, string input)
        {
            var collection = context.Books
                .Where(b => b.Author.LastName.ToLower().StartsWith(input.ToLower()))
                .Select(b => new
                {
                    b.BookId,
                    b.Title,
                    b.Author.FirstName,
                    b.Author.LastName
                })
                .ToList()
                .OrderBy(b => b.BookId);

            var result = new StringBuilder();

            foreach (var book in collection)
            {
                result.Append($"{book.Title} ({book.FirstName} {book.LastName})");
                result.Append(Environment.NewLine);
            }
            
            return result.ToString();
        }

        public static int CountBooks(BookShopContext context, int lengthCheck)
        {
            var collection = context.Books
                .Where(b => b.Title.Length > lengthCheck)
                .Select(b => new
                {
                    b.BookId
                })
                .ToList()
                .Count;
            
            return collection;
        }

        public static string CountCopiesByAuthor(BookShopContext context)
        {
            var collection = context.Books
                .GroupBy(b => $"{b.Author.FirstName} {b.Author.LastName}")
                .Select(g => new
                {
                    g.Key,
                    Copies = g.Sum(b => b.Copies)

                })
               .OrderByDescending(g => g.Copies)
               .ToList();
            
            var result = new StringBuilder();

            foreach (var book in collection)
            {
                result.Append($"{book.Key} - {book.Copies}");
                result.Append(Environment.NewLine);
            }
            
            return result.ToString();
        }

        public static string GetTotalProfitByCategory(BookShopContext context)
        {
            var collection = context.Categories
                .Select(c => new
                {
                    Category = c.Name,                    
                    Profit = c.CategoryBooks.Sum(b => b.Book.Price * b.Book.Copies)
                })
                .OrderByDescending(a => a.Profit)
                .ThenBy(b => b.Category)
                .ToList();
            
            var result = new StringBuilder();

            foreach (var book in collection)
            {
                result.Append($"{book.Category} ${book.Profit:F2}");
                result.Append(Environment.NewLine);
            }
            
            return result.ToString();
        }

        public static string GetMostRecentBooks(BookShopContext context)
        {
//            var groupedCategories = context
//                .Categories
//                .GroupBy(c => c)
//                .Select(g => new
//                {
//                    Category = g.Key,
//                    Books = g.ToArray()
//                });
//            
//            var categories = context
//                .Categories
//                .Select(c => new
//                {
//                    Category = c,
//                    Books = c.CategoryBooks
//                        .Select(cb => cb.Book)
//                        .OrderBy(b => b.Title)
//                        .ToArray()
//                });

            var collection = context.Categories
                .Select(c => new
                {
                    CategoryName = c.Name,
                    BookCount = c.CategoryBooks.Count(),
                    Books = c.CategoryBooks.Select(cb => new
                    {
                        Title = cb.Book.Title,
                        Year = cb.Book.ReleaseDate
                    }).OrderByDescending(cb => cb.Year)
                        .Take(3)
                        .ToList()
                }).OrderBy(c => c.CategoryName)
                .ToList();

            var result = new StringBuilder();

            foreach (var category in collection)
            {
                result.Append($"--{category.CategoryName}");
                result.Append(Environment.NewLine);

                foreach (var details in category.Books)
                {
                    result.Append($"{details.Title} ({details.Year:yyyy})");
                    result.Append(Environment.NewLine);
                }
            }
            
            return result.ToString();
        }

        public static void IncreasePrices(BookShopContext context)
        {
            var booksToBeRepriced = context.Books.Where(b =>
                b.ReleaseDate < DateTime.ParseExact("2010", "yyyy", new DateTimeFormatInfo()))
                .ToList();
            
            for (int i = 0; i < booksToBeRepriced.Count; i++)
            {
                booksToBeRepriced[i].Price += 5;
            }
            
            context.SaveChanges();
        }

        public static int RemoveBooks(BookShopContext context)
        {
            var books = context.Books
                .Where(b => b.Copies < 4200)
                .ToList();

            foreach (var book in books)
            {
                context.Books.Remove(book);
            }

            context.SaveChanges();

            return books.Count();
        }
    }
}
