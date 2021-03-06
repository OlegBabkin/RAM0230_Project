﻿using System;
using System.ComponentModel.DataAnnotations;
using System.Web.Mvc;

namespace Project.UI.WebMVCApp.Models.VisitViewModels
{
    public class PartialVisitsVisitViewModel
    {
        [HiddenInput(DisplayValue = false)]
        public int Id { get; set; }

        public DateTime? Date { get; set; }

        [Display(Name = "Lesson type")]
        public string LessonType { get; set; }

        [Display(Name = "Pair number")]
        public int? PairNumber { get; set; }

        [HiddenInput(DisplayValue = false)]
        public int Subject_Techer_Id { get; set; }

        [Display(Name = "Teacher")]
        public string TeacherName { get; set; }

        [Display(Name = "Subject")]
        public string SubjectName { get; set; }
    }
}