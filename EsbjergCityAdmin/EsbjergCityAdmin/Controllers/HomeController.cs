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

        public ActionResult Index()
        {
            return View(_og.GetAll());
        }

        public ActionResult AcceptOrder(int id)
        {
            var orderToComplete = _og.Get(id);
            orderToComplete.IsCompleted = true;
            _og.Update(orderToComplete);
            return RedirectToAction("Index");
        }

        public ActionResult OrderDetails(int id)
        {
            var orderToComplete = _og.Get(id);
            return View(orderToComplete);
        }
    }
}