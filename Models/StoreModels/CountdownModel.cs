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

        public string FormatProductName(dynamic dynamicSingleProduct)
        {
            string productName = dynamicSingleProduct.ProductName[0].text.ToString();
            productName = productName.Replace("\"", "");
            Debug.WriteLine(productName, "productName");
            return productName;
        }
        public float FormatPrice(dynamic dynamicSingleProduct)
        {
            String dollarPrice = dynamicSingleProduct.Price[0].text.ToString();
            dollarPrice = dollarPrice.Substring(1);
            float finalPrice = float.Parse(dollarPrice, CultureInfo.InvariantCulture.NumberFormat);
            Debug.WriteLine(finalPrice, "finalPrice");
            return finalPrice;
        }
        public float FormatPreviousPrice(JObject singleProduct)
        {
            JProperty rawPreviousPrice = singleProduct.Property("PreviousPrice");
            float PreviousPrice = ProcessPreviousPrice(rawPreviousPrice);
            Debug.WriteLine(PreviousPrice, "PreviousPrice");
            return PreviousPrice;
        }
        ///<summary>
        ///If Previous Price is found then it on sale else it is null
        ///</summary>
        private float ProcessPreviousPrice(JProperty rawPreviousPrice)
        {
            if (rawPreviousPrice != null)
            {
                String PreviousPrice = rawPreviousPrice.Value[0]["text"].ToString();
                PreviousPrice = PreviousPrice.Substring(5);
                Debug.WriteLine(PreviousPrice, "PreviousPrice THERE");
                return float.Parse(PreviousPrice, CultureInfo.InvariantCulture.NumberFormat);
            }
            else
            {
                Debug.WriteLine("PreviousPrice NULL");
                return 0;
            }
        }
    }
}