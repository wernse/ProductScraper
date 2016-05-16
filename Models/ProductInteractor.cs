using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Threading.Tasks;
using System.Diagnostics;

namespace angularJS.Models.ProductData
{
    public interface IProductInteractor
    {
        Task<string> ScrapeAndStoreData();
        List<Product> GetProducts();
        string DeleteProducts();
    }
    public class ProductInteractor: IProductInteractor
    {
        IData DataSource = new DataSource();
        IDataFormat ProductDataFormat = new ProductDataFormat();
        IDbOperations DbOperations = new DbOperations();

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
        public List<Product> GetProducts()
        {
            List<Product> products = DbOperations.GetProducts();
            return products;
        }
        public string DeleteProducts()
        {
            DbOperations.DeleteProducts();
            return "Success";
        }

    }
}