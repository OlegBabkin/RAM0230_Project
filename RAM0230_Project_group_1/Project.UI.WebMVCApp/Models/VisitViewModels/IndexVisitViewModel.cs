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

        [Display(Name = "Code")]
        public string Code { get; set; }

        [Display(Name = "Title")]
        public string Title { get; set; }

        [Display(Name = "Mode of study")]
        public string ModeOfStudy { get; set; }

        [Display(Name = "Language")]
        public string Language { get; set; }
    }
}