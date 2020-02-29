using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace PRSLibrary {
    public class RequestController {

        public const string StatusNew        =  "NEW";
        public const string StatusEdit       =  "EDIT";
        public const string StatusReview     =  "REVIEW";
        public const string StatusApproved   =  "APPROVED";
        public const string StatusRejected   =  "REJECTED";

        private readonly AppDbContext context = new AppDbContext();

        public IEnumerable<Request> GetRequestsToReviewNotOwn(int userId) {
            return context.Requests.Where(x => x.UserId != userId && x.Status == StatusReview).ToList();
        }
        public bool SetToReview(Request request) {
           if(request.Total <= 50) {
                request.Status = StatusApproved;
            } else { 
                request.Status = StatusReview;
            }
            return Update(request.Id, request);
            //request.Status = StatusReview;
            //return Update(request.Id, request);
        }

        public bool SetToApproved(Request request) {
            request.Status = StatusApproved;
            return Update(request.Id, request);
        }

        public bool SetToRejected(Request request) {
            request.Status = StatusRejected;
            return Update(request.Id, request);
        }

        public IEnumerable<Request> GetAll() {
            return context.Requests.ToList();
        }

        public Request GetByPk(int id) {
            if (id < 1) throw new Exception("Id must be GT zero");
            return context.Requests.Find(id);
        }

        public Request Insert (Request request) {
            if (request == null) throw new Exception("Request cannot be null");
            // edit checking here
            context.Requests.Add(request);
            try {
                context.SaveChanges();
            } catch (DbUpdateException ex) {
                throw new Exception("Code must be unique", ex);
            } catch (Exception) {
                throw;
            }
            return request;
        }

        public bool Update(int id, Request request) {
            if (request == null) throw new Exception("Request cannot be null");
            if (id != request.Id) throw new Exception("Id and Request.Id must match");

            context.Entry(request).State = EntityState.Modified;
            try {
                context.SaveChanges();
            } catch (DbUpdateException ex) {
                throw new Exception(ex.Message, ex);
            } catch (Exception) {
                throw;
            }
            return true;
        }

        public bool Delete(int id) {
            if (id <= 0) throw new Exception("Id must be GT zero");
            var request = context.Requests.Find(id);
            return Delete(request);
        }

        public bool Delete(Request request) {
            context.Requests.Remove(request);
            context.SaveChanges();
            return true;
        }

    }
}
