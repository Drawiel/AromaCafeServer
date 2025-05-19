using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;

namespace AromaCafeService.Models
{
    [DataContract]
    public class ProductOrder
    {
        private int productId;
        private int quantity;

        [DataMember]
        public int ProductId { get { return productId; } set { productId = value; } }
        [DataMember]
        public int Quantity { get { return quantity; } set { quantity = value; } }
    }
}
