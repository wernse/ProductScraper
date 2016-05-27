using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Web;

namespace angularJS.DbRepository
{
    public interface IDbOperations
    {
        ///<summary>
        ///Retrieves all products from the database
        ///</summary>
        List<Product> GetProducts();
        ///<summary>
        ///Stores the data retrieved from IData into a sql db
        ///</summary>
        void SaveProducts(List<Product> formattedProducts);

        ///<summary>
        ///Stores the data retrieved from IData into a sql db
        ///</summary>
        void DeleteProducts();
    }
    public class DbOperations : IDbOperations
    {
        private ProductContext db = new ProductContext();
        ///<summary>
        ///<see cref="IDbManipulation.SaveProducts(List<Product> formattedProducts)"/>
        ///</summary>
        public void SaveProducts(List<Product> formattedProducts)
        {
            foreach (Product item in formattedProducts)
            {
                db.Products.Add(item);

            }
            db.SaveChanges();
        }
        ///<summary>
        ///<see cref="IDbManipulation.DeleteProducts()"/>
        ///</summary>
        public void DeleteProducts()
        {
            using (ProductContext db = new ProductContext())
            {
                db.Database.ExecuteSqlCommand("TRUNCATE TABLE Products");
            }
            //
        }
        ///<summary>
        ///<see cref="IDbManipulation.GetProducts()"/>
        ///</summary>
        public List<Product> GetProducts()
        {
            using (ProductContext db = new ProductContext())
            {
                var query = from b in db.Products
                            select b;

                Debug.WriteLine("All Products in the database:");
                foreach (var item in query)
                {
                    Debug.WriteLine(item.ProductName);
                }

                return db.Products.ToList();
            }
        }
    }
}