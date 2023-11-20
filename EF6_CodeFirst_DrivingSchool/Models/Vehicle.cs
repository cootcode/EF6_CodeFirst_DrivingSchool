using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace EF6_CodeFirst_DrivingSchool.Models
{
    public class Vehicle
    {
        [Key]
        public int VehicleId { get; set; }
        public string VehicleDetails { get; set; }

        //NAVIGATIONAL PROPERTIES
        public List<Lesson> Lessons { get; set; }
    }
}