using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace PRSLibrary {
    public class VendorController {
        private AppDbContext context = new AppDbContext();

        public IEnumerable<Vendor> GetAll() {
            return context.Vendors.ToList();
        }
        public Vendor GetByPk(int id) {
            if (id < 1) throw new Exception("Id must be GT zero");
            return context.Vendors.Find(id);
        }
        //first check to see if the user is null
        public Vendor Insert(Vendor vendor) {
            if (vendor == null) throw new Exception("Vendor cannot be null");
            //edit checking here
            context.Vendors.Add(vendor);
            try {
                context.SaveChanges();
            } catch (DbUpdateException ex) {
                throw new Exception("Code must be unique", ex);
            } catch (Exception ex) {
                throw;
            }
            return vendor;
        }
        //first check to see if the user is null
        public bool Update(int id, Vendor vendor) {
            if (vendor == null) throw new Exception("Code cannot be null");
            if (id != vendor.Id) throw new Exception("Id and Code.Id must match");
            context.Entry(vendor).State = EntityState.Modified;

            try {
                context.SaveChanges();
            } catch (DbUpdateException ex) {
                throw new Exception("Code must be unique", ex);
            } catch (Exception ex) {
                throw;
            }
            return true;
            //if it doesnt have an exception, it means it worked

        }
        public bool Delete(int id) {
            if (id <= 0) throw new Exception("Id must be GT zero");
            var vendor = context.Vendors.Find(id);
            return Delete(vendor);

        }
        public bool Delete(Vendor vendor) {
            context.Vendors.Remove(vendor);
            context.SaveChanges();
            return true;
        }
    }


}
