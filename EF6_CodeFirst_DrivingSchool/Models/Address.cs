using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace EF6_CodeFirst_DrivingSchool.Models
{
    public class Address
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int AddressId { get; set; }
        public int BuildingNumber { get; set; }
        public string StreetName { get; set; }
        public string City { get; set; }
        public string Postcode { get; set; }
        public string Country { get; set; }
        public string OtherAddressDetails { get; set; }


        //NAVIGATIONAL PROPERTIES
        public List<Customer> Customers { get; set; }
        public List<Staff> Staffs { get; set;}
    }
}