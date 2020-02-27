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
            user = userCtrl.Insert(user);
            Console.WriteLine(user);
            user.Firstname = "Vaughn";
            user.Lastname = "Cunningham";
            userCtrl.Update(user.Id, user);
            Console.WriteLine("Update successful!");
            userCtrl.GetAll().ToList().ForEach(u => Console.WriteLine(u));
            userCtrl.Delete(user);
            Console.WriteLine("Delete Successful!");


        }
        static void AddProducts(AppDbContext context, int rowsAffected) {
            var product1 = new Product { Id = 0, PartNbr = "Product1", Name = "Echo", Price = 50.00m, Unit = "2", VendorId = 30 };
            var product2 = new Product { Id = 0, PartNbr = "Product2", Name = "AppleWatch", Price = 300.00m, Unit = "3", VendorId = 31 };
            var product3 = new Product { Id = 0, PartNbr = "Product3", Name = "Big Echo", Price = 60.00m, Unit = "2", VendorId = 32 };
            var product4 = new Product { Id = 0, PartNbr = "Product4", Name = "Small Echo", Price = 40.00m, Unit = "1", VendorId = 33 };
            var product5 = new Product { Id = 0, PartNbr = "Product5", Name = "Airpods", Price = 149.00m, Unit = "4", VendorId = 34 };

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
