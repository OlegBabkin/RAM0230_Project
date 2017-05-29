using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Project.UI.WebMVCApp.Models.VisitViewModels
{
    public class IndexVisitViewModel
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
    }
}