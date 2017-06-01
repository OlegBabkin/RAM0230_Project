using AutoMapper;
using Project.Domain.Core;
using Project.Domain.Repository;
using Project.UI.WebMVCApp.Models;
using Project.UI.WebMVCApp.Models.VisitViewModels;
using System.Collections.Generic;
using System.Web.Mvc;

namespace Project.UI.WebMVCApp.Controllers
{
    [Authorize]
    public class VisitsController : Controller
    {
        private IUnitOfWork uow;
        private int userId = 0;
        private string userRole = "";

        public VisitsController(IUnitOfWork uow) { this.uow = uow; }

        // GET: Visits
        public ActionResult Index()
        {
            ViewBag.Title = "Students attendance control page";

            userId = User.Identity.GetUserId<int>();
            userRole = User.Identity.GetUserRole();

            Mapper.Initialize(cfg => cfg.CreateMap<Subject, IndexVisitViewModel>()
                .ForMember(dest => dest.ModeOfStudy, opt => opt.MapFrom(src => src.ModeOfStudy.Name)));
            if (userRole.Equals("teacher"))
            {
                var subjects = Mapper.Map<IEnumerable<Subject>, List<IndexVisitViewModel>>(
                    uow.Subjects.GetSubjectsByTeacherId(userId));
                return View(subjects);
            }
            //Mapper.Initialize(cfg => cfg.CreateMap<Visit, IndexVisitViewModel>()
            //    .ForMember(dest => dest.TeacherName, opt => opt.MapFrom(src => src.Subject_teacher.User.Name + " " + src.Subject_teacher.User.Lastname))
            //    .ForMember(dest => dest.SubjectName, opt => opt.MapFrom(src => src.Subject_teacher.Subject.Title)));
            //if (userRole.Equals("teacher"))
            //{
            //    var visits = Mapper.Map<IEnumerable<Visit>, List<IndexVisitViewModel>>(
            //        uow.Visits.FindBy(v => v.Subject_teacher.TeacherId == userId));
            //    return View(visits);
            //}

            if (userRole.Equals("student"))
            {
                User studentUser = uow.Users.GetByKey(userId);
                if (studentUser.StudentCode.Length > 0)
                {
                    Student student = uow.Students.GetByKey(studentUser.StudentCode);
                    if (student != null)
                    {
                        var subjects = Mapper.Map<IEnumerable<Subject>, List<IndexVisitViewModel>>(student.Subjects);
                        return View(subjects);
                    }
                    
                }
                return RedirectToAction("Index", "Home");
            }
            return RedirectToAction("Index", "Home");
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
