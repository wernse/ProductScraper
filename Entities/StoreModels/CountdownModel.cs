using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Newtonsoft.Json.Linq;
using System.Diagnostics;
using System.Globalization;

namespace angularJS.Models.StoreModels
{

    ///<summary>
    ///Holds the tmp items for the return
    ///</summary>
    public class CountdownModel : IProductObject
    {
        public CountdownModel()
        {
            this.Store = "countdown";
        }
        public string ProductName { get; set; }
        public double Price { get; set; }
        public double PreviousPrice { get; set; }
        public string Store { get; set; }

        /// <summary>
        /// <see cref="IProductObject.FormatProductName(JObject singleProduct)"/>
        /// </summary>
        /// <param name="dynamicSingleProduct"></param>
        /// <returns></returns>
        public string FormatProductName(dynamic dynamicSingleProduct)
        {
            string productName = dynamicSingleProduct.ProductName[0].text.ToString();
            productName = productName.Replace("\"", "");
            return productName;
        }
        /// <summary>
        /// <see cref="IProductObject.FormatPrice(JObject singleProduct)"/>
        /// </summary>
        /// <param name="dynamicSingleProduct"></param>
        /// <returns></returns>
        public double FormatPrice(dynamic dynamicSingleProduct)
        {
            String dollarPrice = dynamicSingleProduct.Price[0].text.ToString();
            dollarPrice = dollarPrice.Substring(1);
            double finalPrice = double.Parse(dollarPrice, CultureInfo.InvariantCulture.NumberFormat);
            return finalPrice;
        }
        /// <summary>
        /// <see cref="IProductObject.FormatPreviousPrice(JObject singleProduct)"/>
        /// </summary>
        /// <param name="singleProduct"></param>
        /// <returns></returns>
        public double FormatPreviousPrice(JObject singleProduct)
        {
            JProperty rawPreviousPrice = singleProduct.Property("PreviousPrice");
            double PreviousPrice = ProcessPreviousPrice(rawPreviousPrice);
            return PreviousPrice;
        }
        /// <summary>
        /// If Previous Price is found then it on sale else it is null
        /// </summary>
        /// <param name="rawPreviousPrice"></param>
        /// <returns>Double or 0</returns>
        private double ProcessPreviousPrice(JProperty rawPreviousPrice)
        {
            if (rawPreviousPrice != null)
            {
                String PreviousPrice = rawPreviousPrice.Value[0]["text"].ToString();
                PreviousPrice = PreviousPrice.Substring(5);
                Debug.WriteLine(PreviousPrice, "PreviousPrice THERE");
                return double.Parse(PreviousPrice, CultureInfo.InvariantCulture.NumberFormat);
            }
            else
            {
                Debug.WriteLine("PreviousPrice NULL");
                return 0;
            }
        }
    }
}