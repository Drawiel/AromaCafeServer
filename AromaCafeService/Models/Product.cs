using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ServiceModel;
using System.Runtime.Serialization;

namespace AromaCafeService.Models
{
    [DataContract]
    public class Product
    {
        private int productId;
        private string productName;
        private string description;
        private decimal? unitPrice;
        private int? stock;
        private string productType;

        [DataMember]
        public int ProductId { get { return productId; } set { productId = value; } }

        [DataMember]
        public string ProductName { get { return productName; } set { productName = value; } }

        [DataMember]
        public string Description { get { return description; } set { description = value; } }

        [DataMember]
        public decimal? UnitPrice { get { return unitPrice; } set { unitPrice = value; } }

        [DataMember]
        public int? Stock { get { return stock; } set { stock = value; } }

        [DataMember]
        public string ProductType { get { return productType; } set { productType = value; } }
    }
}
