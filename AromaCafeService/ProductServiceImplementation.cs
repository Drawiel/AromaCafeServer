using AromaCafeService.Models;
using DataAccess;
using System;
using System.Collections.Generic;
using DataAccess;
using System.Linq;



namespace AromaCafeService
{
    public partial class ServiceImplementation : IProductManager
    {
        public List<Product> GetAllProducts()
        {
            List<Producto> products = ProductManagerDB.GetAllProducts();
            List<Product> allProducts = products.Select(p => new Product {
                ProductName = p.NombreProducto,
                Description = p.Descripcion,
                Stock = p.Stock,
                UnitPrice = p.PrecioUnitario,
                ProductType = p.TipoProducto,
                ProductId = p.idProducto
            }).ToList();
            return allProducts;
        }

        public Product GetProduct(int idProduct)
        {
            Producto producto = ProductManagerDB.GetProductInfo(idProduct);
            Product product = new Product();
            if(producto != null)
            {
                product.ProductId = idProduct;
                product.ProductName = producto.NombreProducto;
                product.ProductType = producto.TipoProducto;
                product.Description = producto.Descripcion;
                product.Stock = producto.Stock;
                product.UnitPrice = producto.PrecioUnitario;
            }
            return product;
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
        public int UpdateProduct(Product product)
        {
            var updatedProduct = new Producto
            {
                NombreProducto = product.ProductName,
                Stock=product.Stock,
                Descripcion = product.Description,
                idProducto = product.ProductId,
                TipoProducto = product.ProductType,
                Categoria = product.ProductType,
                PrecioUnitario=product.UnitPrice,
            };

            int productUpdated = ProductManagerDB.UpdateProduct(updatedProduct);
            return productUpdated;
        }

    }
}
