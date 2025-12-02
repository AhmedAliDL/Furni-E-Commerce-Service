namespace Furni_E_Commerce_Service.Models
{
    public class CartItems
    {
        public int CartItemId { get; set; }
        public int ShoppingCartId { get; set; }
        public int Quantity { get; set; }

        public ShoppingCart ShoppingCart { get; set; }

        public virtual ICollection<ProductsCartItems> ProductsCartItems { get; set; }

    }

}
