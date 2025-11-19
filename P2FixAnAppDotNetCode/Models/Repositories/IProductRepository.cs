using System.Collections.Generic;

namespace P2FixAnAppDotNetCode.Models.Repositories
{
    public interface IProductRepository
    {
        // Début MODIFICATION
        List<Product> GetAllProducts();
        // Fin MODIFICATION
        // Product[] GetAllProducts();

        void UpdateProductStocks(int productId, int quantityToRemove);
    }
}
