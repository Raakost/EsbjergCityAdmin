using Gateway;
using Gateway.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace EsbjergCityAdmin.Controllers
{
    public class EventsController : Controller
    {
        private readonly IServiceGateway<Event> _eg = new Facade().GetEventGateway();

        [HttpGet]
        public ActionResult Index()
        {
            return View(_eg.GetAll());
        }

        [HttpGet]
        public ActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public ActionResult CreateEvent(Event e)
        {
            _eg.Create(e);
            return RedirectToAction("Index");
        }

        public ActionResult Edit(int id)
        {
            return View(_eg.Get(id));
        }

        public ActionResult Delete()
        {
            return View(_eg.GetAll());
        }


    }
}