using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Project.UI.WebMVCApp.Models
{
    public class IndexVisitViewModel
    {
        [HiddenInput(DisplayValue = false)]
        public int Id { get; set; }

        public System.DateTime? Date { get; set; }

        [Display(Name = "Lesson type")]
        public string LessonType { get; set; }

        [Display(Name = "Pair number")]
        public int? PairNumber { get; set; }

        [Display(Name = "Subject title")]
        public string SubjectTitle { get; set; }
    }
}