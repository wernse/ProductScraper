using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace angularJS.Models
{
    public class Product
    {
        public Product()
        {
        }
        public int ProductID { get; set; }
        public string ProductName { get; set; }
        public double Price { get; set; }
        public double PreviousPrice { get; set; }
        public DateTime DateSaved { get; set; }
        public string Store { get; set; }
        public string Category { get; set; }
}

    public class ProductContext : DbContext
    {
        public ProductContext() : base("DefaultConnection")
        {

        }
        public DbSet<Product> Products { get; set; }

    }
}