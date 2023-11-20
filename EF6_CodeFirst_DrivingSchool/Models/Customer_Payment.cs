using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace EF6_CodeFirst_DrivingSchool.Models
{
    public class Customer_Payment
    {
        [Column(Order = 0), Key, ForeignKey("Customer")]
        public int CustomerId { get; set; }
        public Customer Customer { get; set; }
        [Column(Order = 1), Key]
        public DateTime DateTimePayment { get; set; }
        public decimal AmountPayment { get; set; }
        public string OtherPaymentDetails { get; set; }


        //NAVIGATIONAL PROPERTIES
        [ForeignKey("Ref_Payment_Methods")]
        public int PaymentMethodCode { get; set; }
        public Ref_Payment_Method Ref_Payment_Methods { get; set; }
    }
}