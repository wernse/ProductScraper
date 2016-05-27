using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using angularJS.DbRepository;

namespace angularJS.Models.ProductData
{
    public interface IProductInteractor
    {
        /// <summary>
        ///Queries a website for products and saves it into a db
        /// </summary>
        /// <returns>async Success message</returns>
        Task<string> ScrapeAndStoreData();
        /// <summary>
        /// Queries the DB for products
        /// </summary>
        /// <returns>A List of Products</returns>
        List<Product> GetProducts();
        /// <summary>
        /// Deletes all products in the DB
        /// </summary>
        /// <returns>Success message</returns>
        string DeleteProducts();
    }
    public class ProductInteractor: IProductInteractor
    {
        IData DataSource = new DataSource();
        IDataFormat ProductDataFormat = new ProductDataFormat();
        IDbOperations DbOperations = new DbOperations();

        /// <summary>
        /// <see cref="IProductInteractor.ScrapeAndStoreData()"/>
        /// </summary>
        public async Task<string> ScrapeAndStoreData()
        {
            IData DataSource = new DataSource();
            IEnumerable<string> results = await DataSource.FetchData();
            foreach (var rawDataFetched in results.Select((value, i) => new { i, value }))
            {
                List<Product> formattedProducts = ProductDataFormat.GetFormattedProducts(rawDataFetched.value,rawDataFetched.i);
                DbOperations.SaveProducts(formattedProducts);
            }
            return "Success";
        }
        /// <summary>
        /// <see cref="IProductInteractor.GetProducts()"/>
        /// </summary>
        public List<Product> GetProducts()
        {
            List<Product> products = DbOperations.GetProducts();
            return products;
        }
        /// <summary>
        /// <see cref="IProductInteractor.DeleteProducts()"/>
        /// </summary>
        public string DeleteProducts()
        {
            DbOperations.DeleteProducts();
            return "Success";
        }

    }
}