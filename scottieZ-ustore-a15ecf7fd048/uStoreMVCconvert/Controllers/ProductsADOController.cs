using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using uStoreMVC.Data.Ado;
using uStoreMVC.Domain;

namespace uStoreMVCconvert.Controllers
{
    public class ProductsADOController : Controller
    {
        productsDAL products = new productsDAL();


        // GET: ProductsADO
        public ActionResult Index()
        {
            ViewBag.products = products.GetProducts();
            return View();
        }//end index

        public ActionResult GetProducts()
        {
            return View(products.GetProducts());
        }//end getproducts
        
        public ActionResult CreateProducts()
        {
            return View();
        }//end createproducts

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult CreateProducts(ProductModel prod)
        {
            if (ModelState.IsValid)
            {
                products.CreateProducts(prod);
                return RedirectToAction("GetProducts");
            }
            else
            {
                return View(products);
            }
        }

        public ActionResult UpdateProduct (int id, int fk)
        {
            return View(products.GetProduct(id, fk));
        }//end updateproduct()

        //update product post
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult UpdateProduct(ProductModel product)
        {
            if (ModelState.IsValid)
            {
                products.UpdateProduct(product);
                return RedirectToAction("GetProducts");
            }
            return View(product);
        }//end update product post


        public ActionResult DeleteProduct(int id)
        {
            products.DeleteProduct(id);
            return RedirectToAction("GetProducts");
        }
        
    }
}