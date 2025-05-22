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
        public int EditOrderQuantity(int tableId, string productOrderName,int quantity)
        {
            return OrderManagerDB.EditOrderQuantity(tableId, productOrderName, quantity);
        }

        public List<ProductOrder> GetOrdersByTable(int idTable)
        {
            List<OrderProductDTO> products = OrderManagerDB.GetOrdersByTable(idTable);
            List<ProductOrder> orders = products.Select(p => new ProductOrder
            {
                ProductName = p.NombreProducto,
                Quantity = p.Cantidad,
                OrderState = p.EstadoPedido,
                Price = p.Precio

            }).ToList();
            return orders;
        }

        public int MarkOrderAsDelivered(int tableId, string productOrderName)
        {
            return OrderManagerDB.MarkOrderAsDelivered(tableId, productOrderName, "Entregado");
        }

        public int MarkOrderAsRequested(int tableId, string productOrderName)
        {
            return OrderManagerDB.MarkOrderAsDelivered(tableId, productOrderName, "Solicitado");
        }

        public int RegisterOrder(List<ProductOrder> productsOrdered, int idTable, string orderType)
        {
            //return OrderManagerDB.RegisterOrder(productsOrdered, idTable, orderType);
            return 0;
        }
    }
}
