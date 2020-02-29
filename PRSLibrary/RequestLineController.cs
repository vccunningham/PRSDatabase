using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace PRSLibrary {
    public class RequestLineController {
        private readonly AppDbContext context = new AppDbContext();

        private void RecalcRequestTotal(int requestId) {
            var request = context.Requests.Find(requestId);
                request.Total = request.RequestLines.Sum(x => x.Quantity * x.Product.Price);
            //var total = context.Requestlines.Where(rl => rl.RequestId == requestId)
                                                //.Sum(rl => rl.Quantity * rl.Product.Price);

            context.SaveChanges();
        }
        public IEnumerable<RequestLine> GetAll() {
            return context.RequestLines.ToList();
        }
        public RequestLine GetByPk(int id) {
            if (id < 1) throw new Exception("Id must be GT zero");
            return context.RequestLines.Find(id);
        }
        public RequestLine Insert(RequestLine requestLine) {
            if (requestLine == null) throw new Exception("RequestLine cannot be null");
            // edit checking here
            context.RequestLines.Add(requestLine);
            try {
                context.SaveChanges();
                RecalcRequestTotal(requestLine.RequestId);
            } catch (DbUpdateException ex) {
                throw new Exception("Code must be unique", ex);
            } catch (Exception) {
                throw;
            }
            return requestLine;
        }
    }
}

