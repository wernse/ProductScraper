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
        string FormatProductName(dynamic dynamicSingleProduct);
        float FormatPrice(dynamic dynamicSingleProduct);
        float FormatPreviousPrice(JObject singleProduct);

    }
}
