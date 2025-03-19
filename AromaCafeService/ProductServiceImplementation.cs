using AromaCafeService.Models;
using DataAccess;
using System;


namespace AromaCafeService
{
    public class ProductServiceImplementation : IProductManager
    {
        public List<Product> GetAllProducts()
        {
            try
            {
                return ProductManagerDB.GetAllProducts();
            }
            catch (Exception ex)
            {
                return new List<Product>();
            }
        }

        public int AddProduct(Product newProduct)
        {
            try
            {
                return ProductManagerDB.AddProduct(newProduct);
            }
            catch (Exception ex)
            {
                return -1; 
            }
        }

        public int IncreaseStock(int productId, int quantity)
        {
            try
            {
                return ProductManagerDB.IncreaseStock(productId, quantity);
            }
            catch (Exception ex)
            {
                return -1;
            }
        }
    }
}
