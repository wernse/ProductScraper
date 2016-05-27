using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Globalization;
using System.Linq;
using System.Web;

namespace angularJS.Models.StoreModels
{
    public class NewworldModel: IProductObject
    {
        public NewworldModel()
        {
            this.Store = "newworld";
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
        public double FormatPrice(dynamic dynamicSingleProduct)
        {
            String stringDollarPrice = dynamicSingleProduct.Dollar[0].text.ToString();
            if (stringDollarPrice.IndexOf("for")!=-1)
            {
                double needToImplement = 0;
                return needToImplement;
            }
            double dollarPrice = double.Parse(stringDollarPrice, CultureInfo.InvariantCulture.NumberFormat);
            Debug.WriteLine(dollarPrice, "dollarPrice");
            String stringCentPrice = dynamicSingleProduct.Cents[0].text.ToString();
            double wholeCentPrice = double.Parse(stringCentPrice, CultureInfo.InvariantCulture.NumberFormat);
            double centPrice = wholeCentPrice / 100;
            Debug.WriteLine(centPrice, "centPrice");
            double finalPrice = dollarPrice + centPrice;
            return finalPrice;
        }
        public double FormatPreviousPrice(JObject singleProduct)
        {
            double PreviousPrice = 0;
            return PreviousPrice;
        }
    }
}