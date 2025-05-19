using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;

namespace AromaCafeService.Models
{
    
        [DataContract]
        public class TableCustomer
        {
            [DataMember]
            public int TableId { get; set; }
            [DataMember]
            public int NumberPeople { get; set; }
            [DataMember]
            public string TableName { get; set; }
            [DataMember]
            public string TableStatus { get; set; }
        }
}
