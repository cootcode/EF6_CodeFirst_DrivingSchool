using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace EF6_CodeFirst_DrivingSchool.Models
{
    public class DrivingSchoolDbInitializer : DropCreateDatabaseAlways<DrivingSchoolDbContext>
    {
        protected override void Seed(DrivingSchoolDbContext context)
        {
            base.Seed(context);

            //creating some addresses
            Address address1 = new Address()
            {
                BuildingNumber = 10,
                StreetName = "Main St",
                City = "Glasgow",
                Postcode = "G9 123",
                Country = "Scotland",
                OtherAddressDetails = ""
            };

            Address address2 = new Address()
            {
                BuildingNumber = 55,
                StreetName = "South St",
                City = "Wishaw",
                Postcode = "ML9 123",
                Country = "Scotland",
                OtherAddressDetails = ""
            };

            Address address3 = new Address()
            {
                BuildingNumber = 5,
                StreetName = "Happy St",
                City = "Glasgow",
                Postcode = "G9 123",
                Country = "Scotland",
                OtherAddressDetails = ""
            };

            //creating some types of method payments
            Ref_Payment_Method payment_Method1 = new Ref_Payment_Method()
            {
                PaymentMethodDescription = "Credit Card"
            };
            Ref_Payment_Method payment_Method2 = new Ref_Payment_Method()
            {
                PaymentMethodDescription = "Cash"
            };
            Ref_Payment_Method payment_Method3 = new Ref_Payment_Method()
            {
                PaymentMethodDescription = "Debit Card"
            };


            //creating some lesson status

            Ref_Lesson_Status lessonstatus1 = new Ref_Lesson_Status()
            {
                LessonStatusDescription = "Completed"
            };
            Ref_Lesson_Status lessonstatus2 = new Ref_Lesson_Status()
            {
                LessonStatusDescription = "Cancelled"
            };
            Ref_Lesson_Status lessonstatus3 = new Ref_Lesson_Status()
            {
                LessonStatusDescription = "Pending"
            };


            //creating some customer status
            Ref_Customer_Status customer_Status1 = new Ref_Customer_Status()
            {
                CustomerStatusDescription = "Bad"
            };
            Ref_Customer_Status customer_Status2 = new Ref_Customer_Status()
            {
                CustomerStatusDescription = "Ok"
            };
            Ref_Customer_Status customer_Status3 = new Ref_Customer_Status()
            {
                CustomerStatusDescription = "Good"
            };


            //creating some vechicles
            Vehicle vehicle1 = new Vehicle()
            {
                VehicleDetails = "Manual Red Toyota Hylux 2.0L"
            };
            Vehicle vehicle2 = new Vehicle()
            {
                VehicleDetails = "Automatic Blue Kia Sportage 1.5L"
            };

            //creating some customers
            Customer customer1 = new Customer()
            {

                FirstName = "John",
                LastName = "Doe",
                DateOfBirth = new DateTime(1970, 01, 01).Date,
                DateBecameCustomer = new DateTime(2020, 12, 19).Date,
                Email = "johndoe@gmail.com",
                PhoneNumber = "0123456789",
                CellMobilePhoneNumber = "07112233445",
                OtherCustomerDetails = "",
                Address = address2,//navigational property
                Ref_Customer_Status = customer_Status2 //navigational property

            };

            Customer customer2 = new Customer()
            {

                FirstName = "Jack",
                LastName = "Black",
                DateOfBirth = new DateTime(2003, 02, 05).Date,
                DateBecameCustomer = new DateTime(2021, 07, 19).Date,
                Email = "jack@gmail.com",
                PhoneNumber = "0123456789",
                CellMobilePhoneNumber = "07112233445",
                OtherCustomerDetails = "",
                Address = address3,//navigational property
                Ref_Customer_Status = customer_Status1 //navigational property

            };

            Staff staff1 = new Staff()
            {

                FirstName = "Mario",
                MiddleName = "",
                LastName = "Andretti",
                DateOfBirth = new DateTime(1950, 03, 01).Date,
                Nickname = "SuperMario",
                DateJoinedStaff = new DateTime(1975, 01, 05).Date,
                DateLeftStaff = null,
                OtherStaffDetails = "",
                Address = address1//navihational property this is the office address
            };

            Staff staff2 = new Staff()
            {

                FirstName = "Luigi",
                MiddleName = "",
                LastName = "Luigi",
                DateOfBirth = new DateTime(1979, 03, 03).Date,
                Nickname = "SuperLuigi",
                DateJoinedStaff = new DateTime(2000, 01, 05).Date,
                DateLeftStaff = null,
                OtherStaffDetails = "",
                Address = address1//navigational propoerty this is the office address
            };



            Lesson lesson1 = new Lesson()
            {
                Customer = customer1,//navigational property
                Staff = staff1,//navigational property
                LessonDate = new DateTime(2021, 05, 01).Date,
                LessonTime = new DateTime(2021, 05, 01, 10, 30, 00),
                Vehicle = vehicle1,//navigational property
                Price = 30,
                Ref_Lesson_Status = lessonstatus2//navigational properrty
            };
            Lesson lesson2 = new Lesson()
            {
                Customer = customer1,//navigational property
                Staff = staff1,//navigational property
                LessonDate = new DateTime(2021, 05, 08).Date,
                LessonTime = new DateTime(2021, 05, 08, 12, 00, 00),
                Vehicle = vehicle2,//navigational property
                Price = 25,
                Ref_Lesson_Status = lessonstatus3//navigational property
            };
            Lesson lesson3 = new Lesson()
            {
                Customer = customer2,//navigational property
                Staff = staff2,//navigational property
                LessonDate = new DateTime(2021, 05, 18).Date,
                LessonTime = new DateTime(2021, 05, 18, 12, 00, 00),
                Vehicle = vehicle2,//navigational property
                Price = 25,
                Ref_Lesson_Status = lessonstatus3//navigational property
            };

            //SEEDING THE LESSONS TABLE
            context.Lessons.Add(lesson1);
            context.Lessons.Add(lesson2);
            context.Lessons.Add(lesson2);
            context.SaveChanges();//SAVING THE CHANGES TO THE DATABASE  IMPORTANT


            Customer_Payment customer_Payment1 = new Customer_Payment()
            {
                DateTimePayment = new DateTime(2021, 05, 01, 11, 00, 00),//primary key composite
                AmountPayment = 25.00M,
                Ref_Payment_Methods = payment_Method1,//navigational property
                Customer = customer1//primary key composite
            };
            Customer_Payment customer_Payment2 = new Customer_Payment()
            {
                DateTimePayment = new DateTime(2021, 09, 11, 10, 05, 06),//primary key composite
                AmountPayment = 25.00M,
                Ref_Payment_Methods = payment_Method2,//navigational property
                Customer = customer2//primary key composite
            };

            //SEEDING THE CUSTOMER PAYMENTS TABLE
            context.Customer_Payments.Add(customer_Payment1);
            context.Customer_Payments.Add(customer_Payment2);
            context.SaveChanges();//saving the changes to the database



        }
    }
}