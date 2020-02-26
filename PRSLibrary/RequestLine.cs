using System;
using System.Collections.Generic;
using System.Text;
using System.Text.Json.Serialization;

namespace PRSLibrary {
    public class RequestLine {



        public int Id { get; set; }
        public int RequestId { get; set; }
        public int ProductId { get; set; }
        public int Quantity { get; set; }

        [JsonIgnore]
        public virtual Request Request { get; set; }
        public virtual Product Product { get; set; }

        public virtual List<Request> Requests { get; set; }

        public override string ToString()
            => $"{Id}/{Request.Description}/{Product.PartNbr}:{Product.Name}:{Product.Price}/{Quantity}/{Quantity * Product.Price}";

        public RequestLine() { }
    }
        
        
}
