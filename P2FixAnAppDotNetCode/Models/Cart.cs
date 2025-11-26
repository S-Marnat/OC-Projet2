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
        private List<CartLine> _lineCollection = new List<CartLine>();
        public IEnumerable<CartLine> Lines => _lineCollection;
        // Fin MODIFICATION
        // public IEnumerable<CartLine> Lines => GetCartLineList();

        /// <summary>
        /// Return the actual cartline list
        /// </summary>
        /// <returns></returns>
        private List<CartLine> GetCartLineList()
        {
            // Début MODIFICATION
            return _lineCollection;
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
            if (product.Stock == 0)
            {
                return;
            }

            // Vérification si le produit existe déjà dans le panier
            var cartLine = FindProductInCartLines(product.Id);

            if (cartLine != null)
            {
                int newQuantity = cartLine.Quantity + quantity;

                if (product.Stock < newQuantity)
                {
                    cartLine.Quantity = product.Stock;
                }
                else
                {
                    cartLine.Quantity = newQuantity;
                }
                return;
            }

            // Le produit n'existe pas dans le panier, on vérifie la quantité à ajouter avant de l'ajouter
            int quantityToAdd;

            if (product.Stock < quantity)
            {
                quantityToAdd = product.Stock;
            }
            else
            {
                quantityToAdd = quantity;
            }

            _lineCollection.Add(new CartLine
            {
                Product = product,
                Quantity = quantityToAdd
            });
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
            double totalPrice = GetTotalValue();
            int totalQuantity = 0;

            foreach (var cartLine in cartLines)
            {
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
        public CartLine FindProductInCartLines(int productId)
        {
            // TODO implement the method
            // Début MODIFICATION
            var cartLines = GetCartLineList();

            foreach (var cartLine in cartLines)
            {
                if (cartLine.Product.Id == productId)
                {
                    return cartLine;
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
