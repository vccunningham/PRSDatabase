using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace PRSLibrary {
    public class ProductController {
        
            private AppDbContext context = new AppDbContext();

            public IEnumerable<Product> GetAll() {
                return context.Products.ToList();
            }
            public Product GetByPk(int id) {
                if (id < 1) throw new Exception("Id must be GT zero");
                return context.Products.Find(id);
            }
            //first check to see if the user is null
            public Product Insert(Product product) {
                if (product == null) throw new Exception("Product cannot be null");
                //edit checking here
                context.Products.Add(product);
                try {
                    context.SaveChanges();
                } catch (DbUpdateException ex) {
                    throw new Exception("PartNbr must be unique", ex);
                } catch (Exception ex) {
                    throw;
                }
                return product;
            }
            //first check to see if the user is null
            public bool Update(int id, Product product) {
                if (product == null) throw new Exception("PartNbr cannot be null");
                if (id != product.Id) throw new Exception("Id and PartNbr.Id must match");
                context.Entry(product).State = EntityState.Modified;

                try {
                    context.SaveChanges();
                } catch (DbUpdateException ex) {
                    throw new Exception("PartNbr must be unique", ex);
                } catch (Exception ex) {
                    throw;
                }
                return true;
                //if it doesnt have an exception, it means it worked

            }
            public bool Delete(int id) {
                if (id <= 0) throw new Exception("Id must be GT zero");
                var product = context.Products.Find(id);
                return Delete(product);

            }
            public bool Delete(Product product) {
                context.Products.Remove(product);
                context.SaveChanges();
                return true;
            }
        


    }
}