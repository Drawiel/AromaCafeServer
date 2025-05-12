using AromaCafeService.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.ServiceModel;
using System.Text;
using System.Threading.Tasks;

namespace AromaCafeService
{
    [ServiceContract]
    interface IOrderManager
    {
        [OperationContract]
        bool MarkOrderAsDelivered(int idOrder);

        [OperationContract]
        bool EditOrderQuantity(int idOrder, int quantity);

        [OperationContract]
        List<Order> GetAllDeliveredOrders();

        [OperationContract]
        List<Order> GetAllCanceledOrders();
    }
}
