using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;

namespace AromaCafeService.Models {
    [DataContract]
    public class Charge {
        [DataMember]
        public int ChargeId { get; set; }
        [DataMember]
        public int TableId { get; set; }
        [DataMember]
        public decimal TotalCharge { get; set; }
        [DataMember]
        public string TypePayment { get; set; }
        [DataMember]
        public DateTime Date { get; set; }
    }
}
