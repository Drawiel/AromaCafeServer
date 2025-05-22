using System.Runtime.Serialization;

namespace AromaCafeService.Models
{
    [DataContract]
    public class SalesData
    {
        private int index;
        private string tableName;
        private int peopleCount;
        private float total;
        private string paymentMethod;
        private string saleDate;

        [DataMember]
        public int Index { get => index; set => index = value; }

        [DataMember]
        public string TableName { get => tableName; set => tableName = value; }

        [DataMember]
        public int PeopleCount { get => peopleCount; set => peopleCount = value; }

        [DataMember]
        public float Total { get => total; set => total = value; }

        [DataMember]
        public string PaymentMethod { get => paymentMethod; set => paymentMethod = value; }

        [DataMember]
        public string SaleDate { get => saleDate; set => saleDate = value; }
    }
}
