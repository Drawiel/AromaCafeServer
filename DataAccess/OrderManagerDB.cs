using System;
using System.Collections.Generic;
using System.Data.Entity.Core;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess
{
    public class OrderManagerDB
    {
        public static int EditOrderQuantity(int tableId, string productOrderName, int quantity)
        {
            int edited = 0;
            try
            {
                using (var context = new AromaCafeBDEntities())
                {
                    var producto = context.Producto
                        .FirstOrDefault(p => p.NombreProducto == productOrderName);

                    if (producto == null)
                        return 0;

                    int prodId = producto.idProducto;

                    var order = context.Pedido
                        .FirstOrDefault(o =>
                            o.idMesa == tableId &&
                            o.idProducto == prodId);

                    if (order == null)
                        return 0;

                    order.Cantidad = quantity;
                    context.SaveChanges();
                    edited = 1;
                }
            }
            catch (SqlException)
            {
                edited = 2;
            }
            catch (InvalidOperationException)
            {
                edited = 2;
            }
            catch (EntityException)
            {
                edited = 2;
            }
            catch (Exception)
            {
                edited = 2;
            }
            return edited;
        }

        public static List<OrderProductDTO> GetOrdersByTable(int idTable)
        {
            var result = new List<OrderProductDTO>();
            try
            {
                using (var context = new AromaCafeBDEntities())
                {
                    result = (from pedido in context.Pedido
                              where pedido.idMesa == idTable
                              join producto in context.Producto
                              on pedido.idProducto equals producto.idProducto
                              select new OrderProductDTO
                              {
                                  NombreProducto = producto.NombreProducto,
                                  Cantidad = pedido.Cantidad,
                                  EstadoPedido = pedido.EstadoPedido,
                                  PrecioUnitario = (decimal)producto.PrecioUnitario
                              }).ToList();
                }
            }
            catch (SqlException)
            {
                result = new List<OrderProductDTO>();
            }
            catch (InvalidOperationException)
            {
                result = new List<OrderProductDTO>();
            }
            catch (EntityException)
            {
                result = new List<OrderProductDTO>();
            }
            catch (Exception)
            {
                result = new List<OrderProductDTO>();
            }

            return result;
        }

        public static int MarkOrderAsDelivered(int tableId, string productOrderName, string status)
        {
            int marked = 0;
            try
            {
                using (var context = new AromaCafeBDEntities())
                {
                    var producto = context.Producto
                        .FirstOrDefault(p => p.NombreProducto == productOrderName);

                    if (producto == null)
                        return 0;

                    int prodId = producto.idProducto;

                    var order = context.Pedido
                        .FirstOrDefault(o =>
                            o.idMesa == tableId &&
                            o.idProducto == prodId);

                    if (order == null)
                        return 0;

                    order.EstadoPedido = status;
                    context.SaveChanges();
                    marked = 1;
                }
            }
            catch (SqlException)
            {
                marked = 2;
            }
            catch (InvalidOperationException)
            {
                marked = 2;
            }
            catch (EntityException)
            {
                marked = 2;
            }
            catch (Exception)
            {
                marked = 2;
            }
            return marked;
        }

        public static int RegisterNewOrder(List<OrderProductDTO> productsOrdered, int idTable)
        {
            Pedido pedido = new Pedido();
            int result = 0;
            try
            {
                using (var context = new AromaCafeBDEntities())
                {
                    foreach (var product in productsOrdered)
                    {
                        var producto = ProductManagerDB.GetProductInfoByName(product.NombreProducto);
                        var employees = UserManagerDB.GetWorkingEmployees();
                        int employeeId = 1;
                        if(employees != null)
                        {
                            employeeId = employees[0].idEmpleado;
                        }

                        pedido.Cantidad = product.Cantidad;
                        pedido.idMesa = idTable;
                        pedido.idProducto = producto.idProducto;
                        pedido.SubtotalPedido = (decimal)(product.Cantidad * producto.PrecioUnitario);
                        pedido.TipoPedido = "Local";
                        pedido.EstadoPedido = "Solicitado";
                        pedido.idEmpleado = (int?)employeeId;
                    }
                    context.Pedido.Add(pedido);
                    context.SaveChanges();
                    result = 1;
                }
            }
            catch (SqlException)
            {
                result = -1;
            }
            catch (InvalidOperationException)
            {
                result = -1;
            }
            catch (EntityException)
            {
                result = -1;
            }
            catch (Exception)
            {
                result = -1;
            }
            return result;
        }

        public static List<Pedido> GetDeliveredOrders()
        {
            List<Pedido> orders = new List<Pedido>();
            try
            {
                using (var context = new AromaCafeBDEntities())
                {
                    orders = context.Pedido.Where(p => p.EstadoPedido == "Entregado").ToList();
                }
            }
            catch (SqlException)
            {
                orders = null;
            }
            catch (InvalidOperationException)
            {
                orders = null;
            }
            catch (EntityException)
            {
                orders = null;
            }
            catch (Exception)
            {
                orders = null;
            }
            return orders;
        }

        public static List<Pedido> GetCancelledOrders()
        {
            List<Pedido> orders = new List<Pedido>();
            try
            {
                using (var context = new AromaCafeBDEntities())
                {
                    orders = context.Pedido.Where(p => p.EstadoPedido == "Cancelado").ToList();
                }
            }
            catch (SqlException)
            {
                orders = null;
            }
            catch (InvalidOperationException)
            {
                orders = null;
            }
            catch (EntityException)
            {
                orders = null;
            }
            catch (Exception)
            {
                orders = null;
            }
            return orders;
        }
    }
}
