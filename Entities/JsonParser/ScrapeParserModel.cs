using Newtonsoft.Json.Linq;
using angularJS.Models.StoreModels;
using System.Diagnostics;

namespace angularJS.Models
{
    public interface IScrapeParser
    {
        ///<summary>
        ///Parses the a single Json result and returns the db obj
        ///</summary>
        IProductObject parseJson(JObject singleJson, IProductObject tmpProduct);
    }

    public class ScrapeParserModel : IScrapeParser
    {
        /// <summary>
        /// A Custom class to parse ImportIO Json file
        /// </summary>
        /// <param name="singleProduct"></param>
        /// <param name="tmpProduct"></param>
        /// <returns>IProductObject</returns>
        public IProductObject parseJson(JObject singleProduct, IProductObject tmpProduct)
        {
            dynamic dynamicSingleProduct = singleProduct;

            tmpProduct.ProductName = tmpProduct.FormatProductName(dynamicSingleProduct);
            tmpProduct.Price = tmpProduct.FormatPrice(dynamicSingleProduct);
            tmpProduct.PreviousPrice = tmpProduct.FormatPreviousPrice(dynamicSingleProduct);

            return tmpProduct;
        }

    }

}