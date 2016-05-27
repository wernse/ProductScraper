using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace angularJS.DbRepository
{
    /// <summary>
    /// Product object for EF framework
    /// </summary>
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
}