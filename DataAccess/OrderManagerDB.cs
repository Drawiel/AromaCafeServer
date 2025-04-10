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
        public static bool EditOrderQuantity(int idOrder, int quantity)
        {
            bool edited = false;
            try
            {
                using (var context = new AromaCafeBDEntities())
                {
                    var order = context.Pedido.FirstOrDefault(p => p.idPedido == idOrder);
                    if (order != null)
                    {
                        order.Cantidad = quantity;
                        context.SaveChanges();
                        edited = true;
                    }
                }
            }
            catch (SqlException)
            {
                edited = false;
            }
            catch (InvalidOperationException)
            {
                edited = false;
            }
            catch (EntityException)
            {
                edited = false;
            }
            catch (Exception)
            {
                edited = false;
            }
            return edited;
        }

        public static bool MarkOrderAsDelivered(int idOrder)
        {
            bool marked = false;
            try
            {
                using (var context = new AromaCafeBDEntities())
                {
                    var order = context.Pedido.FirstOrDefault(p => p.idPedido == idOrder);
                    if (order != null)
                    {
                        order.EstadoPedido = "Entregado";
                        context.SaveChanges();
                        marked = true;
                    }
                }
            }
            catch (SqlException)
            {
                marked = false;
            }
            catch (InvalidOperationException)
            {
                marked = false;
            }
            catch (EntityException)
            {
                marked = false;
            }
            catch (Exception)
            {
                marked = false;
            }
            return marked;
        }
    }
}
