using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace EF6_CodeFirst_DrivingSchool.Models
{
    public class Staff
    {
        [Key]
        public int StaffId { get; set; }
        public string Nickname { get; set; }
        public string FirstName { get; set; }
        public string MiddleName { get; set; }
        public string LastName { get; set; }
        public DateTime DateOfBirth { get; set; }
        public DateTime DateJoinedStaff { get; set; }
        public DateTime? DateLeftStaff { get; set; }
        public string OtherStaffDetails { get; set; }

        //NAVIGATIONAL PROPERTIES
        [ForeignKey("Address")]
        public int? AddressId { get; set; }
        public Address Address { get; set; }
        public List<Lesson> Lessons { get; set; }
    }
}