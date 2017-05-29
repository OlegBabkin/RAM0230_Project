using AutoMapper;
using Project.Infrastructure.DTO;
using Project.Infrastructure.Services.Interfaces;
using Project.UI.WebMVCApp.Models;
using Project.UI.WebMVCApp.Models.VisitViewModels;
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
            //SelectList subjects = new SelectList(service.GetSubjects(), "Id", "Title");

            ViewBag.Title = "Students attendance control page";
            //ViewBag.Subjects = subjects;
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

        //public ActionResult PartialCreateTeachers()
        //{
        //    IEnumerable<TeacherDTO> teacherDtos = service.GetTeachers();
        //    Mapper.Initialize(cfg => cfg.CreateMap<TeacherDTO, PartialTeachersVisitViewModel>()
        //        .ForMember("TeacherId", opt => opt.MapFrom(src1 => src1.Id))
        //        .ForMember("TeacherInfo", opt => opt.MapFrom(src2 => "[" + src2.Id + "]" + " " + src2.Name + " " + src2.Lastname)));
        //    //SelectList teachersList = 
        //    return PartialView();
        //}

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
