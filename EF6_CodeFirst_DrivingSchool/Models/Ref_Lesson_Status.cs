using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace EF6_CodeFirst_DrivingSchool.Models
{
    public class Ref_Lesson_Status
    {
        public int LessonStatusCode { get; set; }
        public string LessonStatusDescription { get; set; }

        //NAVIGATIONAL PROPERTIES
    }
}