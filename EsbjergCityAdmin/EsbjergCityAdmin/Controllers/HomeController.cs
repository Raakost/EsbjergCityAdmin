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
        private readonly IServiceGateway<Order> _eg = new Facade().GetOrderGateway();

        public ActionResult Index()
        {
            return View(_eg.GetAll());
        }

        public ActionResult AcceptOrder(int id)
        {
            var orderToComplete = _eg.Get(id);
            orderToComplete.IsCompleted = true;
            _eg.Update(orderToComplete);
            return RedirectToAction("Index");
        }

    }
}