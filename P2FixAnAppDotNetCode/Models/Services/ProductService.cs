using P2FixAnAppDotNetCode.Models.Repositories;
using System.Collections.Generic;

namespace P2FixAnAppDotNetCode.Models.Services
{
    /// <summary>
    /// This class provides services to manages the products
    /// </summary>
    public class ProductService : IProductService
    {
        private readonly IProductRepository _productRepository;
        private readonly IOrderRepository _orderRepository;

        public ProductService(IProductRepository productRepository, IOrderRepository orderRepository)
        {
            _productRepository = productRepository;
            _orderRepository = orderRepository;
        }

        /// <summary>
        /// Get all product from the inventory
        /// </summary>
        // Début MODIFICATION
        public List<Product> GetAllProducts()
        {
            return _productRepository.GetAllProducts();
        }
        // Fin MODIFICATION

        //public Product[] GetAllProducts()
        //{
        //    // TODO change the return type from array to List<T> and propagate the change
        //    // throughout the application
        //    return _productRepository.GetAllProducts();
        //}

        /// <summary>
        /// Get a product form the inventory by its id
        /// </summary>
        public Product GetProductById(int id)
        {
            // TODO implement the method
            // Début MODIFICATION
            var products = _productRepository.GetAllProducts();

            foreach (var product in products)
            {
                if (product.Id == id)
                {
                    return product;
                }
            }
            // Fin MODIFICATION
            return null;
        }

        /// <summary>
        /// Update the quantities left for each product in the inventory depending of ordered the quantities
        /// </summary>
        public void UpdateProductQuantities(Cart cart)
        {
            // TODO implement the method
            // update product inventory by using _productRepository.UpdateProductStocks() method.
            // Début MODIFICATION
            var lines = cart.Lines;

            foreach (var line in lines)
            {
                Product product = GetProductById(line.Product.Id);
                if (product != null)
                {
                    product.Stock -= line.Quantity;
                    if (product.Stock <= 0)
                    {
                        _productRepository.UpdateProductStocks(line.Product.Id, line.Quantity);
                    }
                }
            }
            // Fin MODIFICATION
        }
    }
}
