namespace Furni_E_Commerce_Service.Models
{
    public class ProductsCartItemsOfOrder
    {
        public int Id { get; set; }
        public int ProductsId { get; set; }
        public int CartItemsId {  get; set; }
        public int ItemQuantity { get; set; }
        public virtual Products Products { get; set; }
        public virtual CartItems CartItems { get; set; }
    }
}
