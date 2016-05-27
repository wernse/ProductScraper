using System.Data.Entity;

namespace angularJS.DbRepository
{


    public class ProductContext : DbContext
    {
        public ProductContext() : base("DefaultConnection")
        {

        }
        /// <summary>
        /// Stores the products from stores
        /// </summary>
        public DbSet<Product> Products { get; set; }

    }
}