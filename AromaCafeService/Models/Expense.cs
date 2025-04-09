using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;

namespace AromaCafeService.Models {
    internal class Expense {

        [DataMember]
        public float Amount { get; set; }
        [DataMember]
        public DateTime DateTime { get; set; }
        [DataMember]
        public int ExpenseId { get; set; }
    }
}
