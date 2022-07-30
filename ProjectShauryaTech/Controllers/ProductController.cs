using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using ProjectShauryaTech.DAL;
using ProjectShauryaTech.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ProjectShauryaTech.Controllers
{
    public class ProductController : Controller
    {
        ProductDAL db = new ProductDAL();
        CartDAL cdb = new CartDAL();
        OrdersDAL orders = new OrdersDAL();
        // GET: ProductController
        public ActionResult Products()
        {

            var model = db.GetAllProducts();
            return View(model);
        }
        public ActionResult Index()
        {
            var model = db.GetAllProducts();
            return View(model);
        }

        // GET: ProductController/Details/5
        public ActionResult Details(int id)
        {
            var model = db.GetProductById(id);
            return View(model);
        }

        // GET: ProductController/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: ProductController/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(Product product)
        {
            try
            {
                int result = db.AddProduct(product);
                if (result == 1)
                    return RedirectToAction(nameof(Index));
                else
                    return View();
            }
            catch
            {
                return View();
            }
        }

        // GET: ProductController/Edit/5
        public ActionResult Edit(int id)
        {
            var model = db.GetProductById(id);
            return View(model);
        }

        // POST: ProductController/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(Product product)
        {
            try
            {
                int result = db.UpdateProduct(product);
                if (result == 1)
                    return RedirectToAction(nameof(Index));
                else
                    return View();
            }
            catch
            {
                return View();
            }
        }

        // GET: ProductController/Delete/5
        public ActionResult Delete(int id)
        {
            var model = db.GetProductById(id);

            return View(model);
        }

        // POST: ProductController/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        [ActionName("Delete")]
        public ActionResult DeleteConfirmed(int id)
        {
            try
            {
                int result = db.DeleteProduct(id);
                if (result == 1)
                    return RedirectToAction(nameof(Index));
                else
                    return View();
            }
            catch
            {
                return View();
            }
        }
        

        public IActionResult AddToCart(int id)
        {
            string userid = HttpContext.Session.GetString("userid");
            Cart cart = new Cart();
            cart.Pid = id;
            cart.Uid = Convert.ToInt32(userid);
            int res = cdb.Addtocart(cart);
            if (res == 1)
            {
                return RedirectToAction("ViewCart");
            }
            else
            {
                return View();
            }
        }
        [HttpGet]
        public IActionResult ViewCart()
        {
            string userid = HttpContext.Session.GetString("userid");
            var model = cdb.ViewProductsFromCart(userid);
            return View(model);
        }

        public IActionResult RemoveFromCart(int cid)
        {
            int res = cdb.RemoveFromCart(cid);
            if (res == 1)
            {
                return RedirectToAction("ViewCart");
            }
            else
            {
                return View();
            }
        }
        //public IActionResult AddToOrder(int id)
        //{
        //    string userid = HttpContext.Session.GetString("userid");
        //    Orders order = new Orders();
        //         order.Uid=Convert.ToInt32( userid);
        //          order.Pid = id;
        //    int result = orders.AddOrder(order);
        //    if (result == 1)
        //    {
        //        return RedirectToAction("ViewCard");
        //    }
        //    else
        //        return View();
        //}
        //public IActionResult ViewOrders()
        //{

        //}
       

    }
}
