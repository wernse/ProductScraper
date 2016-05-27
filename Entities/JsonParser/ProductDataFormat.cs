using angularJS.Models.StoreModels;
using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using angularJS.DbRepository;

namespace angularJS.Models.ProductData
{

    public interface IDataFormat
    {
        ///<summary>
        ///Parses the raw string and returns the formatted ProductList
        ///</summary>
        List<Product> GetFormattedProducts(string rawFetchedData, int index);
    }

    public class ProductDataFormat : IDataFormat
    {
        /// <summary>
        /// <see cref="IDataFormat.GetFormattedProducts()"/>
        /// </summary>
        public List<Product> GetFormattedProducts(string rawFetchedData, int index)
        {
            DateTime saveTime = DateTime.Now;
            string category = "Meat";

            List<Product> productList = new List<Product>();
            JObject json = JObject.Parse(rawFetchedData);
            Debug.WriteLine(json["extractorData"]["data"], "HELLO2");
            foreach (JObject item in json["extractorData"]["data"][0]["group"])
            {
                IProductObject tmpProduct = CastResult(item, index);
                Product finalProduct = new Product()
                {
                    ProductName = tmpProduct.ProductName,
                    Price = tmpProduct.Price,
                    PreviousPrice = tmpProduct.PreviousPrice,
                    Store = tmpProduct.Store,
                    DateSaved = saveTime,
                    Category = category,
                };
                productList.Add(finalProduct);
                Debug.WriteLine(finalProduct.ProductName, "INNER");
            }
            return productList;
        }
        ///<summary>
        ///Casts the Json String into the Db Obj
        ///</summary>
        private IProductObject CastResult(JObject SingleJson, int index)
        {
            Debug.WriteLine(index);
            IProductObject storeProduct = findStore(index);
            ScrapeParserModel parser = new ScrapeParserModel();
            IProductObject tmpProduct = parser.parseJson(SingleJson, storeProduct);
            return tmpProduct;
        }
        /// <summary>
        /// Creates a product based on store, polymorphs method for different json structures
        /// </summary>
        /// <param name="index"></param>
        /// <returns>product object</returns>
        private IProductObject findStore(int index)
        {
            IProductObject product = null;
            if (isNewworld(index))
            {
                Debug.WriteLine("New World");
                product = new NewworldModel();
            }
            else if (isPaknSave(index))
            {
                Debug.WriteLine("PaknSave");
                //product = new PaknSaveModel();
            }
            else
            {
                Debug.WriteLine("Countdown");
                product = new CountdownModel();
            }
            return product;
        }
        private bool isNewworld(int index)
        {
            return index == 0;
        }
        private bool isPaknSave(int index)
        {
            return index == -1;
        }

    }







}