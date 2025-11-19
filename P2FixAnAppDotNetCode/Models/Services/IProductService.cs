using System.Collections.Generic;

namespace P2FixAnAppDotNetCode.Models.Services
{
    public interface IProductService
    {
        // Début MODIFICATION
        List<Product> GetAllProducts();
        // Fin MODIFICATION
        // Product[] GetAllProducts();
        Product GetProductById(int id);
        void UpdateProductQuantities(Cart cart);
    }
}
