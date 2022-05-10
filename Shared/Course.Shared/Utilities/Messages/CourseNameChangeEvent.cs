using System;
using System.Collections.Generic;
using System.Text;

namespace Course.Shared.Utilities.Messages
{
    public class CourseNameChangeEvent
    {
        public string CourseId { get; set; }
        public string UpdatedName { get; set; }
    }
}
