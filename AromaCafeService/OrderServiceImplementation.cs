using AromaCafeService.Models;
using DataAccess;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AromaCafeService
{
    public partial class ServiceImplementation : IOrderManager
    {
        public bool EditOrderQuantity(int idOrder, int quantity)
        {
            return OrderManagerDB.EditOrderQuantity(idOrder, quantity);
        }

        public bool MarkOrderAsDelivered(int idOrder)
        {
            return OrderManagerDB.MarkOrderAsDelivered(idOrder);
        }

        public int RegisterOrder(List<ProductOrder> productsOrdered, int idTable, string orderType)
        {
            return OrderManagerDB.RegisterOrder(productsOrdered, idTable, orderType);
        }
    }
}
