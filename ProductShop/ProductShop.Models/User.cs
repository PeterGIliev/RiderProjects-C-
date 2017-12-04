using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;

namespace ProductShop.Models
{
    public class User
    {
        public User()
        {
            ProductsBought = new List<Product>();
            ProductsSold = new List<Product>();
        }
        [Column(Order=0)]
        public int Id { get; set; }

        [Column(Order=1)]
        public string FirstName { get; set; }

        [Column(Order=2)]
        public string LastName { get; set; }

        [Column(Order=3)]
        public int? Age { get; set; }

        public ICollection<Product> ProductsBought  { get; set; }

        public ICollection<Product> ProductsSold { get; set; }
    }
}