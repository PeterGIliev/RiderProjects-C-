using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Xml;
using System.Xml.Linq;
using Microsoft.EntityFrameworkCore.Extensions.Internal;
using Microsoft.EntityFrameworkCore.Storage;
using Newtonsoft.Json;
using ProductShop.Data;
using ProductShop.Models;
using Formatting = Newtonsoft.Json.Formatting;

namespace ProductShop.App
{
    public class StartUp
    {
        
        public static void Main(string[] args)
        {
            var context = new ProductShopContext();

//            context.Database.EnsureDeleted();
//            context.Database.EnsureCreated();
            
//            Console.WriteLine(ImportUsersFromJson());
//
//            Console.WriteLine(ImportCategoriesFromJson());
//
//            Console.WriteLine(ImportProductsFromJason());

//            Console.WriteLine(ImportCategoryProducts() );

//            ProductsInRange();
            
//            SuccessfullySoldProducts();

//            CategoriesByProductsCount();
            
//            UsersAndProducts();

//            Console.WriteLine(ImportUsersFromXml());

//            Console.WriteLine(ImportCategoriesFromXml());

//            Console.WriteLine(ImportProductsFromXml());

//            ProductsInRangeXml();

        }

        //JSON------------
        
        static string ImportUsersFromJson()
        {
            string path = "Files/users.json";
            
            User[] users = ImportJson<User>(path);

            using (var context = new ProductShopContext())
            {
                context.Users.AddRange(users);
                context.SaveChanges();
            }

            return $"{users.Length} users were imported from file: {path}";
        }
        
        //JSON------------

        static string ImportCategoriesFromJson()
        {
            string path = "Files/categories.json";

            Category[] categories = ImportJson<Category>(path);

            using (var context = new ProductShopContext())
            {
                context.Categories.AddRange(categories);
                context.SaveChanges();
            }

            return $"{categories .Length} categories were imported from file: {path}";
        }
        
        //JSON------------

        static string ImportProductsFromJason()
        {
            string path = @"Files/products.json";

            var rnd = new Random(); 

            Product[] products = ImportJson<Product>(path);

            using (var context = new ProductShopContext())
            {
                int[] userIds = context.Users.Select(u => u.Id).ToArray();

                foreach (var p in products)
                {
                    int sellerIndex = rnd.Next(0, userIds.Length);
                    int sellerId = userIds[sellerIndex];

                    p.SellerId = sellerId;

                    int? buyerId = sellerId;
                    while (buyerId == sellerId)
                    {
                        int buyerIndex = rnd.Next(0, userIds.Length);
                        buyerId = userIds[buyerIndex];
                    }

                    if (buyerId - sellerId > 0 && buyerId - sellerId < 5)
                    {
                        buyerId = null;
                    }

                    p.BuyerId = buyerId;
                }
                
                context.Products.AddRange(products);
                context.SaveChanges();
            }

            return $"{products.Length} products were imported from file: {path}";
        }
        
        //Mapping Table------------

        static string ImportCategoryProducts()
        {
            using (var context = new ProductShopContext())
            {
                var productIds = context.Products
                    .Select(p => p.Id)
                    .ToArray();

                var categoryIds = context.Categories
                    .Select(c => c.Id)
                    .ToArray();

                var categoryProduct = new List<CategoryProduct>();
                
                var rnd = new Random();
                
                foreach (var pId in productIds)
                {
                    var product = pId;

                    var categoryIndex = rnd.Next(0, categoryIds.Length);
                    var category = categoryIds[categoryIndex];
                    
                    var pc = new CategoryProduct()
                    {
                        ProductId = product,
                        CategoryId = category
                    };
                    
                    categoryProduct.Add(pc);
                }
                
                context.CategoryProducts.AddRange(categoryProduct);
                context.SaveChanges();
                
                return $"{categoryProduct.Count} categories were added to products.";

            }
        }
        
        //JSON Parse------------
        
        static T[] ImportJson<T>(string path)
        {
            string jsonString = File.ReadAllText(path);
                
            T[] objects = JsonConvert.DeserializeObject<T[]>(jsonString);

            return objects;
        }
        
        //--------------Query and write into JSON file-----------

        static void ProductsInRange()
        {
            using (var context = new ProductShopContext())
            {
                var products = context.Products
                    .Where(p => p.Price >= 500 && p.Price <= 1000)
                    .OrderBy(p => p.Price)
                    .Select(p => new
                    {
                        p.Name,
                        p.Price,
                        Seller = $"{p.Seller.FirstName} {p.Seller.LastName}"
                    })
                    .ToList();

                var jsonString = JsonConvert.SerializeObject(products, Formatting.Indented);
                
                File.WriteAllText(@"Writes/products-in-range.json", jsonString );
            }
        }
        
        //Query and write into json file-----------

        static void SuccessfullySoldProducts()
        {
            using (var context = new ProductShopContext())
            {
                var result = context.Users
                    .Where(u => u.ProductsSold.Any(p => p.BuyerId != null))
                    .OrderBy(u => u.LastName)
                    .ThenBy(u => u.FirstName)
                    .Select(u => new
                    {
                        firstName = u.FirstName,
                        lastName = u.LastName,
                        soldProducts = u.ProductsSold
                            .Select(ps => new
                        {
                            name = ps.Name,
                            price = ps.Price,
                            buyerFirstName = ps.Buyer.FirstName,
                            buyerLastName = ps.Buyer.LastName
                        })
                    })
                    .ToList();
 
                var jsonString = JsonConvert.SerializeObject(result, Formatting.Indented, new JsonSerializerSettings()
                {
                    DefaultValueHandling = DefaultValueHandling.Ignore
                });
                File.WriteAllText(@"Writes/users-sold-products.json", jsonString );
            }
        }
        
        //Query and write into json file-----------

        static void CategoriesByProductsCount()
        {
            using (var context = new ProductShopContext())
            {
                var categories = context.Categories
                    .OrderBy(c => c.Name)
                    .Select(c => new
                    {
                        category = c.Name,
                        productsCount = c.CategoryProducts.Count,
                        averagePrice = c.CategoryProducts.Select(cp => cp.Product.Price).Average(),
                        totalRevenue = c.CategoryProducts.Select(cp => cp.Product.Price).Sum()
                    });
                
                var jsonString = JsonConvert.SerializeObject(categories, Formatting.Indented, new JsonSerializerSettings()
                {
                    DefaultValueHandling = DefaultValueHandling.Ignore
                });
                File.WriteAllText(@"Writes/categories-by-products.json", jsonString );
            }
        }
        
        //Query and write into json file-----------

        static void UsersAndProducts()
        {
            using (var context = new ProductShopContext())
            {
                var users = context.Users
                    .Where(u => u.ProductsSold.Count > 0)
                    .OrderByDescending(u => u.ProductsSold.Count)
                    .ThenBy(u => u.LastName)
                    .Select(u => new
                    {
                        firstName = u.FirstName,
                        lastName = u.LastName,
                        age = u.Age,
                        
                        soldProducts = u.ProductsSold.Select(ps => new
                        {
                            name = ps.Name,
                            price = ps.Price
                        })
                    });
                
                var jsonString = JsonConvert.SerializeObject(users, Formatting.Indented, new JsonSerializerSettings()
                {
                    DefaultValueHandling = DefaultValueHandling.Ignore
                });
                File.WriteAllText(@"Writes/users-and-products.json", jsonString );

            }
        }
        
        //XML-------------

        static string ImportUsersFromXml()
        {
            var path = @"Files/users.xml";
            
            var xmlString = File.ReadAllText(path);
            
            var xmlDoc = XDocument.Parse(xmlString);

            var elements = xmlDoc.Root.Elements();
            
            var users = new List<User>();

            foreach (var e in elements)
            {
                string firstName = e.Attribute("firstName")?.Value;
                string lastNaem = e.Attribute("lastName")?.Value;

                int? age = null;
                if (e.Attribute("age") != null)
                {
                    age = int.Parse(e.Attribute("age").Value);
                }
                
                var user = new User()
                {
                    FirstName = firstName,
                    LastName = lastNaem,
                    Age = age
                };
                
                users.Add(user);
            }
            
            using (var context = new ProductShopContext())
            {
                context.Users.AddRange(users);
                context.SaveChanges();
            }
            
            return $"{users.Count} users were imported from file: {path}";
        }
        
        //XML-------------

        static string ImportCategoriesFromXml()
        {
            var path = @"Files/categories.xml";
            
            var xmlString = File.ReadAllText(path);
            
            var xmlDoc = XDocument.Parse(xmlString);

            var elements = xmlDoc.Root.Elements();
            
            var categories = new List<Category>();

            foreach (var e in elements)
            {
                string name = e.Element("name")?.Value;
                
                var category = new Category()
                {
                    Name = name
                };
                
                categories.Add(category);
            }
            
            using (var context = new ProductShopContext())
            {
                context.Categories.AddRange(categories);
                context.SaveChanges();
            }
            
            return $"{categories.Count} categories were imported from file: {path}";
        }
        
        //XML-------------

        static string ImportProductsFromXml()
        {
            var path = @"Files/products.xml";
            
            var xmlString = File.ReadAllText(path);
            
            var xmlDoc = XDocument.Parse(xmlString);

            var elements = xmlDoc.Root.Elements();
            
            var catproducts = new List<CategoryProduct>();

            using (var context = new ProductShopContext())
            {
                var userIds = context.Users.Select(u => u.Id).ToArray();
                var categoryIds = context.Categories.Select(c => c.Id).ToArray();
                
                var rnd = new Random();
                
                foreach (var e in elements)
                {
                    string name = e.Element("name")?.Value;
                    decimal price = decimal.Parse(e.Element("price").Value);

                    int sellerindex = rnd.Next(0, userIds.Length);
                    int sellerId = userIds[sellerindex];
                    
                    var product = new Product()
                    {
                        Name = name,
                        Price = price,
                        SellerId = sellerId
                    };
                    
                    int categoryIndex = rnd.Next(0, categoryIds.Length);
                    int categoryId = categoryIds[categoryIndex];
                    var catproduct = new CategoryProduct()
                    {
                        Product = product,
                        CategoryId = categoryId
                    };
                    
                    catproducts.Add(catproduct);
                }
                
                context.AddRange(catproducts);
                context.SaveChanges();
            }
                        
            return $"{catproducts.Count} products were imported from file: {path}";
        }
        
        //Query and write into xml file-----------

        static void ImportUsers()
        {
            using (var context = new ProductShopContext())
            {
                var names = context.Users.Select(u => $"{u.FirstName} {u.LastName}").ToArray();
                
                var xDoc = new XDocument();
                xDoc.Add(new XElement("user"));

                foreach (var n in names)
                {
                    xDoc.Root.Add(new XElement("user", new XElement("name", n)));
                }

                string xmlString = xDoc.ToString();
                
                File.WriteAllText(@"Writes/userexport.xml", xmlString);
            }
        }

        //Query and write into xml file-----------

        static void ProductsInRangeXml()
        {
            using (var context = new ProductShopContext())
            {
                var products = context.Products
                    .Where(p => p.Price >= 500 && p.Price <= 1000)
                    .OrderBy(p => p.Price)
                    .Select(p => new
                    {
                        p.Name,
                        p.Price,
                        Seller = $"{p.Seller.FirstName} {p.Seller.LastName}"
                    })
                    .ToList();
                
                var xDoc = new XDocument();
                xDoc.Add(new XElement("products"));

                foreach (var n in products)
                {
                    xDoc.Root.Add(new XElement("product", n));
                }

                string xmlString = xDoc.ToString();
                
                File.WriteAllText(@"Writes/products-in-range.xml", xmlString);
            }
        }
    }
}