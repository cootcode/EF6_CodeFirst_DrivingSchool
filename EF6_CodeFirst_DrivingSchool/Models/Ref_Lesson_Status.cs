using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace EF6_CodeFirst_DrivingSchool.Models
{
    public class Ref_Lesson_Status
    {
        [Key]
        public int LessonStatusCode { get; set; }
        public string LessonStatusDescription { get; set; }

        //NAVIGATIONAL PROPERTIES
        public List<Lesson> Lessons { get; set; }
    }
}