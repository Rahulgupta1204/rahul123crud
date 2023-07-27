using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using mvccrudoperations.Models;

namespace mvccrudoperations.Controllers
{
    public class ProductController : Controller
    {
        // GET: Product

        public ActionResult Index()
        {
            List<product_master> productList = new List<product_master>();
            using (DBModels dBModel = new DBModels()) 
            {
                productList = dBModel.product_master.ToList<product_master>();    
            }
            return View(productList);
        }

        // GET: Product/Details/5
        public ActionResult Details(int id)
        {
            product_master productModel = new product_master();
            using (DBModels dbModel = new DBModels())
            {
                productModel = dbModel.product_master.Where(x => x.product_id == id).FirstOrDefault();
            }
            return View(productModel);
        }

        // GET: Product/Create
        public ActionResult Create()
        {
            return View(new product_master());
        }

        // POST: Product/Create
        [HttpPost]
        public ActionResult Create(product_master productModel)
        {
            using (DBModels dbModel = new DBModels())
            {
                dbModel.product_master.Add(productModel);
                dbModel.SaveChanges();
            }
            return RedirectToAction("Index");
        }

        // GET: Product/Edit/5
        public ActionResult Edit(int id)
        {
            product_master productModel = new product_master();
            using (DBModels dbModel = new DBModels())
            {
                productModel = dbModel.product_master.Where(x => x.product_id == id).FirstOrDefault();
            }
            return View(productModel);
        }

        // POST: Product/Edit/5
        [HttpPost]
        public ActionResult Edit(product_master productModel)
        {
            using (DBModels dbModel = new DBModels())
            {
                dbModel.Entry(productModel).State = System.Data.EntityState.Modified;
                dbModel.SaveChanges();
            }
            return RedirectToAction("Index");
        }

        // GET: Product/Delete/5
        public ActionResult Delete(int id)
        {
            product_master productModel = new product_master();
            using (DBModels dbModel = new DBModels())
            {
                productModel = dbModel.product_master.Where(x => x.product_id == id).FirstOrDefault();
            }
            return View(productModel);
        }

        // POST: Product/Delete/5
        [HttpPost]
        public ActionResult Delete(int id, FormCollection collection)
        {
            using (DBModels dbModel = new DBModels())
            {
                product_master productModel=dbModel.product_master.Where(x => x.product_id == id).FirstOrDefault();
                dbModel.product_master.Remove(productModel);
                dbModel.SaveChanges();
            }
            return RedirectToAction("Index");
        }
    }
}
