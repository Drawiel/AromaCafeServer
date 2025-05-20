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
        int MarkOrderAsDelivered(int tableId, string productOrderName);
        [OperationContract]
        int MarkOrderAsRequested(int tableId, string productOrderName);
        [OperationContract]
        int EditOrderQuantity(int tableId, string productOrderName, int quantity);
        [OperationContract]
        int RegisterOrder(List<ProductOrder> productsOrdered, int idTable, string orderType);
        [OperationContract]
        List<ProductOrder> GetOrdersByTable(int idTable);

    }
}
