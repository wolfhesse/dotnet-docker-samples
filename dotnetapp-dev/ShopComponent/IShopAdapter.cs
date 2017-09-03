#region

using WooCommerceNET.WooCommerce.v2;

#endregion

namespace dotnetapp.ShopComponent
{
    public interface IShopAdapter
    {
        Product AddProduct(Product product);
    }
}