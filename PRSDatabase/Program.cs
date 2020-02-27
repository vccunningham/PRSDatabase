using PRSLibrary;
using System;
using System.Linq;

namespace PRSDatabase {
    class Program {
        static void Main(string[] args) {

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


    }

}
