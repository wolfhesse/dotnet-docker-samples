#region using directives

using WooCommerceNET.WooCommerce.v2;

#endregion

namespace DotnetApp.AseFramework.Core.ShopComponent
{
    #region using directives

    #endregion

    /// <summary>
    ///     The ShopAdapter interface.
    /// </summary>
    public interface IShopAdapter
    {
        /// <summary>
        ///     The add product.
        /// </summary>
        /// <param name="product">
        ///     The product.
        /// </param>
        /// <returns>
        ///     The <see cref="Product" />.
        /// </returns>
        Product AddProduct(Product product);
    }
}