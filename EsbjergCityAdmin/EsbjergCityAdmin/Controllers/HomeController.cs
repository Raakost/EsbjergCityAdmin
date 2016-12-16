using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Gateway;
using Gateway.Models;

namespace EsbjergCityAdmin.Controllers
{
    public class HomeController : Controller
    {
        private readonly IServiceGateway<Order> _og = new Facade().GetOrderGateway();

        [HttpGet]
        public ActionResult Index()
        {
            return View(_og.GetAll());
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult AcceptOrder(int id)
        {
            var orderToComplete = _og.Get(id);
            orderToComplete.IsCompleted = true;
            _og.Update(orderToComplete);
            return RedirectToAction("Index");
        }

        [HttpGet]
        public ActionResult OrderDetails(int id)
        {
            var orderToComplete = _og.Get(id);
            return View(orderToComplete);
        }

        [HttpGet]
        public ActionResult Delete(int id)
        {
            return View(_og.Get(id));
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Delete(Order o)
        {
            _og.Delete(o);
            return RedirectToAction("Index");
        }
    }
}