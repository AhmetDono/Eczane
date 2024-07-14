using EntityLayer.Concrete;

namespace E_czane.Models
{
    public class CheckoutViewModel
    {
        public List<CartItemViewModel> CartItems { get; set; }
        public List<Address> Addresses { get; set; }
        public int SelectedAddressId { get; set; }
    }

    public class CartItemViewModel
    {
        public Drug Drug { get; set; }
        public int Quantity { get; set; }
        public double Price { get; set; }
    }
}
