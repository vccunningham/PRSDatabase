using System;
using System.Collections.Generic;
using System.Text;
using System.ComponentModel.DataAnnotations;

namespace PRSLibrary {
    public class Request {

        public int Id { get; set; }
        public string Description { get; set; }
        public string Justification { get; set; }
        public string RejectionReason { get; set; }
        public string DeliveryMode { get; set; }
        public string Status { get; set; }
        public decimal Total { get; set; }
        public int UserId { get; set; }

        public override string ToString() => $"{Id}/{Description}/{Justification}/{RejectionReason}/{DeliveryMode}/{Status}/{Total}/{UserId}";

        public virtual List<RequestLine> RequestLines { get; set; }
        public virtual List<User> Users { get; set; }

        public Request() {

        }

    }
}
