using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace EF6_CodeFirst_DrivingSchool.Models
{
    public class Lesson
    {
        [Key]
        public int LessonId { get; set; }
        public DateTime LessonDate { get; set; }
        public DateTime LessonTime { get; set; }
        public decimal Price { get; set; }
        public string OtherLessonDetails { get; set; }

        //NAVIGATIONAL PROPERTIES
        [ForeignKey("Staff")]
        public int StaffId { get; set; }
        public Staff Staff { get; set; }

        [ForeignKey("Customer")]
        public int CustomerId { get; set; }
        public Customer Customer { get; set; }
        [ForeignKey("Vehicle")]
        public int VehicleId { get; set; }
        public Vehicle Vehicle { get; set; }
        [ForeignKey("Ref_Lesson_Status")]
        public int LessonStatusCode { get; set; }
        public Ref_Lesson_Status Ref_Lesson_Status { get; set; }
    }
}