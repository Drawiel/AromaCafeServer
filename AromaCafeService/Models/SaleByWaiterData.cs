using System.Runtime.Serialization;

namespace AromaCafeService.Models
{
    [DataContract]
    public class SaleByWaiterData
    {
        private int index;
        private string fullName;
        private float totalSale;

        [DataMember]
        public int Index { get => index; set => index = value; }

        [DataMember]
        public string FullName { get => fullName; set => fullName = value; }

        [DataMember]
        public float TotalSale { get => totalSale; set => totalSale = value; }
    }
}
