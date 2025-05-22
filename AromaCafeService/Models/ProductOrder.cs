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
        private string productName;
        private int quantity;
        private string orderState;
        private decimal price;

        [DataMember]
        public string ProductName { get { return productName; } set { productName = value; } }
        [DataMember]
        public int Quantity { get { return quantity; } set { quantity = value; } }
        [DataMember]
        public string OrderState { get { return orderState; } set { orderState = value; } }
        [DataMember]
        public decimal Price { get { return price; } set { price = value; } }
    }
}
