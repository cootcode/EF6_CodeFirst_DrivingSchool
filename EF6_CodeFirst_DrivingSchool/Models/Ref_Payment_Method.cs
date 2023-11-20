using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace EF6_CodeFirst_DrivingSchool.Models
{
    public class Ref_Payment_Method
    {
        [Key]
        public int PaymentMethodCode { get; set; }
        public string PaymentMethodDescription { get; set; }

        //NAVIGATIONAL PROPERTIES
        public List<Customer_Payment> CustomerPayment { get; set; }
    }
}