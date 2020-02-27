using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace PRSLibrary {
    public class UserController {

        private AppDbContext context = new AppDbContext();

        public List<User> GetAll() {

            return context.Users.ToList();
        }
        public User GetByPk(int id) {
            if (id < 1) throw new Exception("Id must be GT zero");
            return context.Users.Find(id);
        }
        //first check to see if the user is null
        public User Insert(User user) {
            if (user == null) throw new Exception("User cannot be null");
            //edit checking here
            context.Users.Add(user);
            try {
                context.SaveChanges();
            } catch(DbUpdateException ex) {
                throw new Exception("Username must be unique", ex);            
            } catch(Exception ex) {
                throw ex;
            }
            return user;
        }
        //first check to see if the user is null
        public bool Update(int id, User user) {
            if (user == null) throw new Exception("User cannot be null");
            if (id != user.Id) throw new Exception("Id and User.Id must match");
            context.Entry(user).State = EntityState.Modified;

            try {
                context.SaveChanges();
            } catch (DbUpdateException ex) {
                throw new Exception("Username must be unique", ex);
            } catch (Exception ex) {
                throw ex;
            }
            return true;
            //if it doesnt have an exception, it means it worked

        }
        public bool Delete(int id) {
            if (id <= 0) throw new Exception("Id must be GT zero");
            var user = context.Users.Find(id);
            return Delete(user);
            
        }
        public bool Delete(User user) {
            context.Users.Remove(user);
            context.SaveChanges();
            return true;
        }
    }
    
}
// (user user)
//var userDB = context.Users.Find(userId);
//userDB.username = user.Username;
//SaveChanages()