using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;

namespace Web.Models.Catalogs
{
    public class CourseCreateInput
    {
        public string UserId { get; set; }

        [Display(Name = "Kurs Kategori")]
      
        public string CategoryId { get; set; }

        [Display(Name = "Kurs İsim")]
       
        public string Name { get; set; }

        public string Picture { get; set; }

        [Display(Name = "Kurs Açıklama")]
       
        public string Description { get; set; }

        [Display(Name = "Kurs Fiyat")]
       
        public decimal Price { get; set; }

        public FeatureViewModel Feature { get; set; }

        [Display(Name = "Kurs Resim")]
        public IFormFile PhotoFormFile { get; set; }
    }
}
