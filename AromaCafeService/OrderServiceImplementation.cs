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

        public List<Order> GetAllCanceledOrders() {
            List<Pedido> result = OrderManagerDB.GetCancelledOrders();
            List<Order> orders = new List<Order>();

            foreach (Pedido pedido in result) {
                Order order = new Order {
                    IdOrder = pedido.idPedido,
                    IdTable = pedido.idMesa,
                    IdEmployee = pedido.idEmpleado,
                    IdProduct = pedido.idProducto,
                    Quantity = pedido.Cantidad,
                    OrderType = pedido.TipoPedido,
                    StatusOrder = pedido.EstadoPedido,
                    TotalOrder = pedido.SubtotalPedido
                };
                orders.Add(order);
            }
            return orders;
        }

        public List<Order> GetAllDeliveredOrders() {
            List<Pedido> result = OrderManagerDB.GetDeliveredOrders();
            List<Order> orders = new List<Order>();

            foreach (Pedido pedido in result) {
                Order order = new Order {
                    IdOrder = pedido.idPedido,
                    IdTable = pedido.idMesa,
                    IdEmployee = pedido.idEmpleado,
                    IdProduct = pedido.idProducto,
                    Quantity = pedido.Cantidad,
                    OrderType = pedido.TipoPedido,
                    StatusOrder = pedido.EstadoPedido,
                    TotalOrder = pedido.SubtotalPedido
                };
                orders.Add(order);
            }
            return orders;
        }

        public bool MarkOrderAsDelivered(int idOrder)
        {
            return OrderManagerDB.MarkOrderAsDelivered(idOrder);
        }
    }
}
