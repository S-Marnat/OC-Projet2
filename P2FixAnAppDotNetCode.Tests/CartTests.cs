using System.Collections.Generic;
using System.Linq;
using P2FixAnAppDotNetCode.Models;
using P2FixAnAppDotNetCode.Models.Repositories;
using P2FixAnAppDotNetCode.Models.Services;
using Xunit;

namespace P2FixAnAppDotNetCode.Tests
{
    /// <summary>
    /// The Cart test class
    /// </summary>
    public class CartTests
    {
        [Fact]
        public void AddItemInCart()
        {
            Cart cart = new Cart();
            Product product1 = new Product(1, 10, 20, "name", "description");
            Product product2 = new Product(1, 10, 20, "name", "description");

            cart.AddItem(product1, 1);
            cart.AddItem(product2, 1);

            Assert.NotEmpty(cart.Lines);
            Assert.Single(cart.Lines);
            Assert.Equal(2, cart.Lines.First().Quantity);
        }

        [Fact]
        public void AddItemInCart_Add2DifferentsItems_LinesCount2Quantity1()
        {
            Cart cart = new Cart();
            Product product1 = new Product(1, 10, 20, "name", "description");
            Product product2 = new Product(2, 10, 20, "name", "description");

            cart.AddItem(product1, 1);
            cart.AddItem(product2, 1);

            Assert.NotEmpty(cart.Lines);
            Assert.Equal(2, cart.Lines.Count());
            foreach (var line in cart.Lines)
            {
                Assert.Equal(1, line.Quantity);
            }
        }

        [Fact]
        public void AddItemInCart_NoStock_NotAdd()
        {
            Cart cart = new Cart();
            Product product1 = new Product(1, 0, 20, "name", "description");

            cart.AddItem(product1, 1);

            Assert.Empty(cart.Lines);
        }

        [Fact]
        public void AddItemInCart_NoEnoughStock_MaximumAdd()
        {
            Cart cart = new Cart();
            Product product1 = new Product(1, 2, 20, "name", "description");

            cart.AddItem(product1, 3);

            Assert.Equal(2, cart.Lines.First().Quantity);
        }

        [Fact]
        public void GetAverageValue()
        {
            ICart cart = new Cart();
            IProductRepository productRepository = new ProductRepository();
            IOrderRepository orderRepository = new OrderRepository();
            IProductService productService = new ProductService(productRepository, orderRepository);

            IEnumerable<Product> products = productService.GetAllProducts();
            cart.AddItem(products.First(p => p.Id == 2), 2);
            cart.AddItem(products.First(p => p.Id == 5), 1);
            double averageValue = cart.GetAverageValue();
            double expectedValue = (9.99 * 2 + 895.00) / 3;

            Assert.Equal(expectedValue, averageValue);
        }

        [Fact]
        public void GetTotalValue()
        {
            ICart cart = new Cart();
            IProductRepository productRepository = new ProductRepository();
            IOrderRepository orderRepository = new OrderRepository();
            IProductService productService = new ProductService(productRepository, orderRepository);

            IEnumerable<Product> products = productService.GetAllProducts();
            cart.AddItem(products.First(p => p.Id == 1), 1);
            cart.AddItem(products.First(p => p.Id == 4), 3);
            cart.AddItem(products.First(p => p.Id == 5), 1);
            double totalValue = cart.GetTotalValue();
            double expectedValue = 92.50 + 32.50 * 3 + 895.00;

            Assert.Equal(expectedValue, totalValue);
        }

        [Fact]
        public void FindProductInCartLines()
        {
            Cart cart = new Cart();
            Product product = new Product(999, 2, 20, "name", "description");

            cart.AddItem(product, 1);
            CartLine result = cart.FindProductInCartLines(999);

            Assert.NotNull(result);
        }
    }
}