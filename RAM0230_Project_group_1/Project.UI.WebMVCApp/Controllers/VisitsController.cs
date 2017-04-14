using AutoMapper;
using Project.Infrastructure.DTO.Visit;
using Project.Infrastructure.Services.Interfaces;
using Project.UI.WebMVCApp.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Project.UI.WebMVCApp.Controllers
{
    public class VisitsController : Controller
    {
        IAttendanceService service;
        public VisitsController(IAttendanceService service) { this.service = service; }

        // GET: Visits
        public ActionResult Index()
        {
            IEnumerable<VisitDTO> visitDtos = service.GetVisits();
            Mapper.Initialize(cfg => cfg.CreateMap<VisitDTO, IndexVisitViewModel>());
            var visits = Mapper.Map<IEnumerable<VisitDTO>, List<IndexVisitViewModel>>(visitDtos);
            ViewBag.Visits = visits;
            return View(visits);
        }

        // GET: Visits/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        // GET: Visits/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Visits/Create
        [HttpPost]
        public ActionResult Create(FormCollection collection)
        {
            try
            {
                // TODO: Add insert logic here

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        // GET: Visits/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        // POST: Visits/Edit/5
        [HttpPost]
        public ActionResult Edit(int id, FormCollection collection)
        {
            try
            {
                // TODO: Add update logic here

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        // GET: Visits/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: Visits/Delete/5
        [HttpPost]
        public ActionResult Delete(int id, FormCollection collection)
        {
            try
            {
                // TODO: Add delete logic here

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }
    }
}
