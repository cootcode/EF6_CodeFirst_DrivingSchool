using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace EF6_CodeFirst_DrivingSchool.Models
{
    public class Ref_Customer_Status
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int CustomerStatusCode { get; set; }
        public string CustomerStatusDescription { get; set; }

        //NAVIGATIONAL PROPERTIES
        public List<Customer> Customers { get; set; }
    }
}