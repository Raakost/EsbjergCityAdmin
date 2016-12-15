using Gateway;
using Gateway.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using EsbjergCityAdmin.Models;

namespace EsbjergCityAdmin.Controllers
{
    public class EventsController : Controller
    {
        private readonly IServiceGateway<Event> _eg = new Facade().GetEventGateway();

        [HttpGet]
        public ActionResult Index(int page = 1)
        {
            var events = _eg.GetAll();
            var itemsPrPage = 8;

            events = events.Where(x => x.DateOfEvent > DateTime.Now).OrderBy(x => x.DateOfEvent).ToList();

            var pagination = new PaginatedViewModel
            {
                ItemsPrPage = itemsPrPage,
                Page = page,
                Events = events.Skip((page - 1) * itemsPrPage).Take(itemsPrPage).ToList(),
                TotalEvents = events.Count
            };

            return View(pagination);
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
            return View();
        }


    }
}