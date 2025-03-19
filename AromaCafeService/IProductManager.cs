using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AromaCafeService
{
    [ServiceContract]
    public interface IProductManager
    {
        [OperationContract]
        List<Product> GetAllProducts();

        [OperationContract]
        int AddProduct(Product newProduct);

        [OperationContract]
        int IncreaseStock(int productId, int quantity);
    }
}
