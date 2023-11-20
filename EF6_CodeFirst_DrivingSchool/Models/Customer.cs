using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace EF6_CodeFirst_DrivingSchool.Models
{
    public class Customer
    {
        [Key]
        public int CustomerId { get; set; }
        public DateTime DateBecameCustomer { get; set; }
        public DateTime DateOfBirth { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public decimal AmountOutstanding { get; set; }
        public string Email { get; set; }
        public string PhoneNumber { get; set; }
        public string CellMobilePhoneNumber { get; set; }
        public string OtherCustomerDetails { get; set; }

        //NAVIGATIONAL PROPERTIES
        [ForeignKey("Address")]
        public int AddressId { get; set; }
        public Address Address { get; set; }

        [ForeignKey("Ref_Customer_Status")]
        public int CustomerStatusCode { get; set; }
        public Ref_Customer_Status Ref_Customer_Status { get; set; }
        public List<Customer_Payment> Customer_Payments { get; set; }
        public List<Lesson> Lessons { get; set; }


    }
}