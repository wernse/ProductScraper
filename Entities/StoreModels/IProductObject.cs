using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace angularJS.Models.StoreModels
{
    public interface IProductObject
    {
        string ProductName { get; set; }
        double Price { get; set; }
        double PreviousPrice { get; set; }
        string Store { get; set; }

        /// <summary>
        /// Gets name from JObject
        /// </summary>
        /// <param name="dynamicSingleProduct"></param>
        /// <returns></returns>
        string FormatProductName(dynamic dynamicSingleProduct);
        /// <summary>
        /// Gets the Price from JObject
        /// </summary>
        /// <param name="dynamicSingleProduct"></param>
        /// <returns></returns>
        double FormatPrice(dynamic dynamicSingleProduct);
        /// <summary>
        /// Gets the Previous Price from JObject
        /// </summary>
        /// <param name="singleProduct"></param>
        /// <returns></returns>
        double FormatPreviousPrice(JObject singleProduct);

    }
}
