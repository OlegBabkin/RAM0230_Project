using AutoMapper;
using Project.Infrastructure.DTO;
using Project.Infrastructure.Services.Interfaces;
using Project.UI.WebMVCApp.Models;
using Project.UI.WebMVCApp.Models.VisitViewModels;
using Project.Domain.Core;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Project.Domain.Repository;

namespace Project.UI.WebMVCApp.Controllers
{
    [Authorize]
    public class VisitsController : Controller
    {
        private IUnitOfWork uow;
        public VisitsController(IUnitOfWork uow) { this.uow = uow; }

        // GET: Visits
        public ActionResult Index()
        {
            Mapper.Initialize(cfg => cfg.CreateMap<Visit, IndexVisitViewModel>()
                .ForMember(dest => dest.TeacherName, opt => opt.MapFrom(src => src.Subject_teacher.User.Name + " " + src.Subject_teacher.User.Lastname))
                .ForMember(dest => dest.SubjectName, opt => opt.MapFrom(src => src.Subject_teacher.Subject.Title)));

            var visits = Mapper.Map<IEnumerable<Visit>, List<IndexVisitViewModel>>(uow.Visits.GetAllEntries());

            ViewBag.Title = "Students attendance control page";
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
