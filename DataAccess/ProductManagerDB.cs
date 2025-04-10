using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.Entity.Core;

namespace DataAccess
{
    public static class ProductManagerDB
    {
        public static List<Producto> GetAllProducts()
        {
            try
            {
                using (var context = new AromaCafeBDEntities())
                {
                    return context.Producto.ToList();
                }
            }
            catch (SqlException)
            {
                return new List<Producto>(); 
            }
            catch (InvalidOperationException)
            {
                return new List<Producto>();
            }
            catch (EntityException)
            {
                return new List<Producto>();
            }
            catch (Exception)
            {
                return new List<Producto>();
            }
        }

        public static Producto GetProductInfo(int productId)
        {
            Producto producto = null;
            try
            {
                using (var context = new AromaCafeBDEntities())
                {
                    producto = context.Producto.FirstOrDefault(p => p.idProducto == productId);
                }
            }
            catch (SqlException)
            {
                producto = new Producto();;
            }
            catch (InvalidOperationException)
            {
                producto = new Producto();;
            }
            catch (EntityException)
            {
                producto = new Producto();;
            }
            catch (Exception)
            {
                producto = new Producto();;
            }
            return producto;
        }

        public static int AddProduct(Producto newProducto)
        {
            int result = 0;
            try
            {
                using (var context = new AromaCafeBDEntities())
                {
                    context.Producto.Add(newProducto);
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

        public static int IncreaseStock(int productId, int quantity)
        {
            int result = 0;
            try
            {
                using (var context = new AromaCafeBDEntities())
                {
                    var product = context.Producto.FirstOrDefault(p => p.idProducto == productId);

                    if (product != null)
                    {
                        product.Stock = (product.Stock ?? 0) + quantity;
                        context.SaveChanges();
                        result = 1; 
                    }
                    else
                    {
                        result = -2; 
                    }
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

        public static int UpdateProduct(Producto updatedProducto)
        {

            int productUpdated = 0;

            try
            {
                using (var context = new AromaCafeBDEntities())
                {
                    var update = (from product in context.Producto where product.idProducto == updatedProducto.idProducto select product).Single();
                    update.idProducto = updatedProducto.idProducto;
                    update.NombreProducto = updatedProducto.NombreProducto;
                    update.TipoProducto = updatedProducto.TipoProducto;
                    update.Categoria = updatedProducto.Categoria;
                    update.Descripcion = updatedProducto.Descripcion;
                    update.Stock = updatedProducto.Stock;

                    productUpdated = context.SaveChanges();
                }
            }
            catch (SqlException)
            {
                productUpdated = -1;
            }
            catch (InvalidOperationException)
            {
                productUpdated = -1;
            }
            catch (EntityException)
            {
                productUpdated = -1;
            }
            catch (Exception)
            {
                productUpdated = -1;
            }
            return productUpdated;
        }

    }
}

