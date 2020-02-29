using PRSLibrary;
using System;
using System.Linq;
using Microsoft.EntityFrameworkCore;

namespace PRSDatabase {
    class Program {
        static void Main(string[] args) {
            
            var context = new AppDbContext();
            {
                
            }

            var userCtrl = new UserController();
            userCtrl.GetAll().ToList().ForEach(u => Console.WriteLine(u));
            Console.WriteLine(userCtrl.GetByPk(1));
            var user = new User();
            user.Id = 1;
            user.Username = "VCCUNNI";
            user.Password = "Train@MAX";
            Console.WriteLine(user);
            user.Firstname = "Vaughn";
            user.Lastname = "Cunningham";
            user.Phone = "555-555-5555";
            user.Email = "u@u.gmail.com";
            user.IsAdmin = true;
            user.IsReviewer = false;
            Console.WriteLine("Update successful!");
            userCtrl.Update(user.Id, user);
            user = userCtrl.Insert(user);


            //userCtrl.GetAll().ToList().ForEach(u => Console.WriteLine(u));
            //userCtrl.Delete(user);
            //Console.WriteLine("Delete Successful!");



        }
        static void AddVendors(AppDbContext context, int rowsAffected) {
            var vendor1 = new Vendor { Id = 1, Code = "101", Name = "Amazon", Address = "1111 Red Lane Dr.", City = "Cincinnati", State = "OH", ZipCode = "45242" };
            var vendor2 = new Vendor { Id = 2, Code = "102", Name = "Nike", Address = "2222 Blue Lane Dr.", City = "Cincinnati", State = "OH", ZipCode = "45244" };
            var vendor3 = new Vendor { Id = 3, Code = "103", Name = "Best Buy", Address = "3333 Yellow Lane Dr.", City = "Cincinnati", State = "OH", ZipCode = "45246" };
            var vendor4 = new Vendor { Id = 4, Code = "104", Name = "Target", Address = "4444 Green Lane Dr.", City = "Cincinnati", State = "OH", ZipCode = "45245" };
            var vendor5 = new Vendor { Id = 5, Code = "105", Name = "Apple", Address = "5555 Orange Lane Dr.", City = "Cincinnati", State = "OH", ZipCode = "45247" };
        }
        static void AddProducts(AppDbContext context, int rowsAffected) {
            var product1 = new Product { Id = 1, PartNbr = "Product1", Name = "Echo", Price = 50.00m, Unit = "2", VendorId = 30 };
            var product2 = new Product { Id = 2, PartNbr = "Product2", Name = "AppleWatch", Price = 300.00m, Unit = "3", VendorId = 31 };
            var product3 = new Product { Id = 3, PartNbr = "Product3", Name = "Big Echo", Price = 60.00m, Unit = "2", VendorId = 32 };
            var product4 = new Product { Id = 4, PartNbr = "Product4", Name = "Small Echo", Price = 40.00m, Unit = "1", VendorId = 33 };
            var product5 = new Product { Id = 5, PartNbr = "Product5", Name = "Airpods", Price = 149.00m, Unit = "4", VendorId = 34 };

            context.AddRange(product1, product2, product3, product4, product5);
            context.SaveChanges();
            //if (rowsAffected != 5) throw new Exception("Five products added");
            //Console.WriteLine("Added 5 products");
        }
     
            //AddProducts(context);
            //AddVendors(context);
            //UpdateCustomerSales(context);
            //AddUsers(context);
            //GetCustomerByPk(context);
            //UpdateCustomer(context);
            //DeleteCustomer(context);
            //GetAllCustomers(context);


        
    }
}
