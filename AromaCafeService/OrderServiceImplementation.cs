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
                Price = p.PrecioUnitario

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

        public int MarkOrderAsCancelled(int tableId, string productOrderName)
        {
            return OrderManagerDB.MarkOrderAsDelivered(tableId, productOrderName, "Cancelado");
        }

        public int RegisterOrder(List<ProductOrder> productsOrdered, int idTable, string orderType)
        {
            List<OrderProductDTO> products = productsOrdered.Select(p => new OrderProductDTO
            {
                NombreProducto = p.ProductName,
                Cantidad = p.Quantity,
            }).ToList();

            int result = OrderManagerDB.RegisterNewOrder(products, idTable);

            return result;
        }

        public List<Order> GetAllCanceledOrders()
        {
            List<Pedido> result = OrderManagerDB.GetCancelledOrders();
            List<Order> orders = new List<Order>();

            foreach (Pedido pedido in result)
            {
                Order order = new Order
                {
                    IdOrder = pedido.idPedido,
                    IdTable = (int)pedido.idMesa,
                    IdEmployee = (int)pedido.idEmpleado,
                    IdProduct = (int)pedido.idProducto,
                    Quantity = pedido.Cantidad,
                    OrderType = pedido.TipoPedido,
                    StatusOrder = pedido.EstadoPedido,
                    TotalOrder = pedido.SubtotalPedido
                };
                orders.Add(order);
            }
            return orders;
        }

        public List<Order> GetAllDeliveredOrders()
        {
            List<Pedido> result = OrderManagerDB.GetDeliveredOrders();
            List<Order> orders = new List<Order>();

            foreach (Pedido pedido in result)
            {
                Order order = new Order
                {
                    IdOrder = pedido.idPedido,
                    IdTable = (int)pedido.idMesa,
                    IdEmployee = (int)pedido.idEmpleado,
                    IdProduct = (int)pedido.idProducto,
                    Quantity = pedido.Cantidad,
                    OrderType = pedido.TipoPedido,
                    StatusOrder = pedido.EstadoPedido,
                    TotalOrder = pedido.SubtotalPedido
                };
                orders.Add(order);
            }
            return orders;
        }

    }
}
