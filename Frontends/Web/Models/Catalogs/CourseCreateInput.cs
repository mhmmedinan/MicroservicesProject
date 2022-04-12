using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Web.Models.Catalogs
{
    public class CourseCreateInput
    {
        public string UserId { get; set; }

        [Display(Name = "Kurs Kategori")]
        [Required]
        public string CategoryId { get; set; }

        [Display(Name = "Kurs İsim")]
        [Required]
        public string Name { get; set; }

        public string Picture { get; set; }

        [Display(Name = "Kurs Açıklama")]
        [Required]
        public string Description { get; set; }

        [Display(Name = "Kurs Fiyat")]
        [Required]
        public decimal Price { get; set; }

        public FeatureViewModel Feature { get; set; }
    }
}
