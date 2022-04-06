using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Web.Models.Catalogs
{
    public class CourseCreateInput
    {
        public string UserId { get; set; }

        public string CategoryId { get; set; }

        public string Name { get; set; }

        public string Picture { get; set; }

        public string Description { get; set; }

        public decimal Price { get; set; }

        public FeatureViewModel Feature { get; set; }
    }
}
