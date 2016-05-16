using angularJS.Models;
using angularJS.Models.ProductData;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using System.Web;
using System.Web.Mvc;

namespace angularJS.Controllers
{
    [RoutePrefix("api")]
    public class ProductDataController : Controller
    {
        IProductInteractor ProductInteractor = new ProductInteractor();

        [Route("GetData")]
        // GET: api/GetData
        ///<summary>
        ///Gets all data from the product table
        ///</summary>
        public ActionResult GetData()
        {
            List<Product> result = ProductInteractor.GetProducts();
            return Json(result, JsonRequestBehavior.AllowGet);
        }

        [Route("ScrapeData")]
        // GET: api/ScrapeData
        ///<summary>
        ///Queries a website for products and saves it into a db
        ///</summary>
        public async Task<ActionResult> ScrapeData()
        {
            string result = await ProductInteractor.ScrapeAndStoreData();
            return Json(result, JsonRequestBehavior.AllowGet);
        }

        [Route("DeleteData")]
        // GET: api/DeleteData
        ///<summary>
        ///Removes all data from the product table
        ///</summary>
        public ActionResult DeleteData()
        {
            ProductInteractor.DeleteProducts();
            return Json("success", JsonRequestBehavior.AllowGet);
        }
    }



}

