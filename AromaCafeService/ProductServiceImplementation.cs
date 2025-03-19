using AromaCafeService.Models;
using DataAccess;
using System;
using System.Collections.Generic;
using DataAccess;
using System.Linq;



namespace AromaCafeService
{
    public class ProductServiceImplementation : IProductManager
    {
        public List<Product> GetAllProducts()
        {
            List<Producto> products = ProductManagerDB.GetAllProducts();
            List<Product> allProducts = products.Select(p => new Product {
                ProductName = p.NombreProducto,
                Description = p.Descripcion,
                Stock = p.Stock,
                UnitPrice = p.PrecioUnitario,
                ProductType = p.TipoProducto
            }).ToList();
            return allProducts;
        }

        public int AddProduct(Product newProduct)
        {
            Producto producto = new Producto() {
                NombreProducto = newProduct.ProductName,
                Descripcion = newProduct.Description,
                Stock = newProduct.Stock,
                PrecioUnitario = newProduct.UnitPrice,
                TipoProducto = newProduct.ProductType
            };
            return ProductManagerDB.AddProduct(producto);
        }

        public int IncreaseStock(int productId, int quantity)
        {
            try
            {
                return ProductManagerDB.IncreaseStock(productId, quantity);
            }
            catch (Exception)
            {
                return -1;
            }
        }
    }
}
