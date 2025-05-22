using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess
{
    public class SalesDataDTO
    {
        public string TableName { get; set; }
        public int PeopleCount { get; set; }
        public float Total { get; set; }
        public string PaymentMethod { get; set; }
        public string SaleDate { get; set; }
    }

}
