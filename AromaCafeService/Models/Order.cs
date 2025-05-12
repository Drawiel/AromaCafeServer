using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;

namespace AromaCafeService.Models {
    [DataContract]
    public class Order {
        [DataMember]
        public int IdOrder { get; set; }
        [DataMember]
        public int IdTable { get; set; }
        [DataMember]
        public int IdEmployee { get; set; }
        [DataMember]
        public int IdProduct { get; set; }
        [DataMember]
        public int Quantity { get; set; }
        [DataMember]
        public string OrderType { get; set; }
        [DataMember]
        public string StatusOrder { get; set; }
        [DataMember]
        public decimal TotalOrder { get; set; }
    }
}
