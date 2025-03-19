using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess
{
    public static class ProductManager
    {
        public static List<Product> GetAllProducts()
        {
            try
            {
                using (var context = new AromaCafeBDEntities())
                {
                    return context.Producto
                        .Select(p => new Product
                        {
                            ProductId = p.idProducto,
                            ProductName = p.NombreProducto,
                            Description = p.Descripcion,
                            UnitPrice = p.PrecioUnitario,
                            Stock = p.Stock,
                            ProductType = p.TipoProducto
                        }).ToList();
                }
            }
            catch (SqlException sqlException)
            {
                return new List<Product>(); 
            }
            catch (InvalidOperationException invalidOperationException)
            {
                return new List<Product>();
            }
            catch (EntityException entityException)
            {
                return new List<Product>();
            }
            catch (Exception exception)
            {
                return new List<Product>();
            }
        }

        public static int AddProduct(Product newProduct)
        {
            int result = 0;
            try
            {
                using (var context = new AromaCafeBDEntities())
                {
                    var productEntity = new Producto
                    {
                        NombreProducto = newProduct.ProductName,
                        Descripcion = newProduct.Description,
                        PrecioUnitario = newProduct.UnitPrice,
                        Stock = newProduct.Stock,
                        TipoProducto = newProduct.ProductType
                    };

                    context.Producto.Add(productEntity);
                    context.SaveChanges();
                    result = 1;
                }
            }
            catch (SqlException sqlException)
            {
                result = -1;
            }
            catch (InvalidOperationException invalidOperationException)
            {
                result = -1;
            }
            catch (EntityException entityException)
            {
                result = -1;
            }
            catch (Exception exception)
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
                    var product = context.Producto.SingleOrDefault(p => p.idProducto == productId);

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
            catch (SqlException sqlException)
            {
                result = -1;
            }
            catch (InvalidOperationException invalidOperationException)
            {
                result = -1;
            }
            catch (EntityException entityException)
            {
                result = -1;
            }
            catch (Exception exception)
            {
                result = -1;
            }
            return result;
        }
    }
}
}
