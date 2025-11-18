using System.Collections.Generic;
using System.Linq;

namespace P2FixAnAppDotNetCode.Models
{
    /// <summary>
    /// The Cart class
    /// </summary>
    public class Cart : ICart
    {
        /// <summary>
        /// Read-only property for display only
        /// </summary>
        // Début MODIFICATION
        private List<CartLine> LineCollection = new List<CartLine>();
        public IEnumerable<CartLine> Lines => LineCollection;
        // Fin MODIFICATION
        // public IEnumerable<CartLine> Lines => GetCartLineList();

        /// <summary>
        /// Return the actual cartline list
        /// </summary>
        /// <returns></returns>
        private List<CartLine> GetCartLineList()
        {
            // Début MODIFICATION
            return LineCollection;
            // Fin MODIFICATION
            // return new List<CartLine>();
        }

        /// <summary>
        /// Adds a product in the cart or increment its quantity in the cart if already added
        /// </summary>//
        public void AddItem(Product product, int quantity)
        {
            // TODO implement the method
            // Début MODIFICATION
           var cartLines = GetCartLineList();

            foreach (var cartLine in cartLines)
            {
                if (cartLine.Product.Id == product.Id)
                {
                    cartLine.Quantity += quantity;
                    return;
                }
            }

            cartLines.Add(new CartLine
            {
                Product = product,
                Quantity = quantity
            });

            return;
            // Fin MODIFICATION
        }

        /// <summary>
        /// Removes a product form the cart
        /// </summary>
        public void RemoveLine(Product product) =>
            GetCartLineList().RemoveAll(l => l.Product.Id == product.Id);

        /// <summary>
        /// Get total value of a cart
        /// </summary>
        public double GetTotalValue()
        {
            // TODO implement the method
            // Début MODIFICATION
            var cartLines = GetCartLineList();
            double total = 0.0;

            foreach (var cartLine in cartLines)
            {
                total += cartLine.Product.Price * cartLine.Quantity;
            }

            return total;
            // Fin MODIFICATION
            // return 0.0;
        }

        /// <summary>
        /// Get average value of a cart
        /// </summary>
        public double GetAverageValue()
        {
            // TODO implement the method
            // Début MODIFICATION
            var cartLines = GetCartLineList();
            double totalPrice = 0.0;
            int totalQuantity = 0;

            foreach (var cartLine in cartLines)
            {
                totalPrice += cartLine.Product.Price * cartLine.Quantity;
                totalQuantity += cartLine.Quantity;
            }

            if (totalQuantity > 0)
            {
                return totalPrice / totalQuantity;
            }
            // Fin MODIFICATION
            return 0.0;
        }

        /// <summary>
        /// Looks after a given product in the cart and returns if it finds it
        /// </summary>
        public Product FindProductInCartLines(int productId)
        {
            // TODO implement the method
            // Début MODIFICATION
            var cartLines = GetCartLineList();

            foreach (var cartLine in cartLines)
            {
                if (cartLine.Product.Id == productId)
                {
                    return cartLine.Product;
                }
            }
            // Fin MODIFICATION

            return null;
        }

        /// <summary>
        /// Get a specific cartline by its index
        /// </summary>
        public CartLine GetCartLineByIndex(int index)
        {
            return Lines.ToArray()[index];
        }

        /// <summary>
        /// Clears a the cart of all added products
        /// </summary>
        public void Clear()
        {
            List<CartLine> cartLines = GetCartLineList();
            cartLines.Clear();
        }
    }

    public class CartLine
    {
        public int OrderLineId { get; set; }
        public Product Product { get; set; }
        public int Quantity { get; set; }
    }
}
