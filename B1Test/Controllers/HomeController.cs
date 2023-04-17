using B1Test.Business.Entity;
using B1Test.Business.Repository;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace B1Test.Controllers
{
    public class HomeController : Controller
    {
        B1TestRepository repo = new B1TestRepository();

        public ActionResult Index()
        {
            return View();
        }

        public ActionResult About()
        {
            ViewBag.Message = "Your application description page.";

            return View();
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }


        [HttpPost]
        public JsonResult getAllItemMaster()
        {
            B1TestRepository repo = new B1TestRepository();
            var result = repo.GetAllItemMaster().ToList();
            
            return Json(result);
        }

        [HttpPost]
        public JsonResult AddEditItemMaster(string data)
        {
            dynamic d = JsonConvert.DeserializeObject<dynamic>(data);
            ItemMaster obj = new ItemMaster();
            //if (!string.IsNullOrEmpty(d.itemID))
            //{
            //    return Json(null);
            //}

            obj.ItemID = d.itemID;
            obj.Amount = d.amount;
            var result = repo.AddEditItemMaster(obj);
            return Json(result);
        }

        [HttpPost]
        public JsonResult DeleteItemMaster(string data)
        {
            dynamic d = JsonConvert.DeserializeObject<dynamic>(data);
            ItemMaster obj = new ItemMaster();

            obj.ItemID = d.itemID;
            var result = repo.DeleteItemMaster(obj);
            return Json(result);
        }

        [HttpPost]
        public JsonResult AddEditSchema(string data)
        {
            dynamic d = JsonConvert.DeserializeObject<dynamic>(data);
            ItemSchema obj = new ItemSchema();
            obj.Alias = d.Alias;
            obj.SchemaID = d.SchemaID;
            obj.Formula = d.Formula;
            obj.Priority = d.Priority;

            var result = repo.AddEditItemSchema(obj);

            return Json(result);
        }


        [HttpPost]
        public JsonResult GetAllItemSchema()
        {
            B1TestRepository repo = new B1TestRepository();
            var result = repo.GetAllItemSchema().ToList();

            return Json(result);
        }

        [HttpPost]
        public JsonResult DeleteSchema(string data)
        {
            dynamic d = JsonConvert.DeserializeObject<dynamic>(data);
            ItemSchema obj = new ItemSchema();

            obj.SchemaID = d.SchemaID;
            var result = repo.DeleteItemSchema(obj);
            return Json(result);
        }

        [HttpPost]
        public JsonResult GetSchemaByID(string data)
        {
            dynamic d = JsonConvert.DeserializeObject<dynamic>(data);
            ItemSchema obj = new ItemSchema();

            obj.SchemaID = d.SchemaID;
            var result = repo.GetSchemaByID(obj);
            return Json(result);
        }

        [HttpPost]
        public JsonResult GetDataToExport(string data)
        {
            //dynamic d = JsonConvert.DeserializeObject<dynamic>(data);
            ItemSchema obj = new ItemSchema();
            Mathos.Parser.MathParser math = new Mathos.Parser.MathParser();

            List<ItemData> Items = new List<ItemData>();
            Items = repo.GetAllSchemaCalc().ToList();

            Items.ForEach(t => t.Formula = math.Parse(t.Formula).ToString());

            return Json(Items);

            //List<ItemMaster> itmList = new List<ItemMaster>();
            //List<ItemSchema> schList = new List<ItemSchema>();
            
            //itmList = repo.GetAllItemMaster().ToList();
            //schList = repo.GetAllItemSchema().ToList();

            //foreach (var item in schList)
            //{
                
            //}


        }


        public JsonResult TestStringCalc(string str)
        {
            //System.Data.DataTable dt = new System.Data.DataTable ();
            //string val = dt.Compute("1 +2+6",null);
            Mathos.Parser.MathParser math = new Mathos.Parser.MathParser();
            decimal d = math.Parse("2+6+5");
            return Json(d,JsonRequestBehavior.AllowGet);

        }

    }
}