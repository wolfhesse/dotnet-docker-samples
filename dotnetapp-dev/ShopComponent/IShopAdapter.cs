#region

#endregion

namespace DotnetApp.ShopComponent
{
    using WooCommerceNET.WooCommerce.v2;

    public interface IShopAdapter
    {
        Product AddProduct(Product product);
    }
}