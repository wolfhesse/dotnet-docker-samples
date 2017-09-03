// --------------------------------------------------------------------------------------------------------------------
// <copyright file="IShopAdapter.cs" company="">
//   
// </copyright>
// <summary>
//   The ShopAdapter interface.
// </summary>
// --------------------------------------------------------------------------------------------------------------------

namespace DotnetApp.ShopComponent
{
    #region

    using WooCommerceNET.WooCommerce.v2;

    #endregion

    /// <summary>
    /// The ShopAdapter interface.
    /// </summary>
    public interface IShopAdapter
    {
        /// <summary>
        /// The add product.
        /// </summary>
        /// <param name="product">
        /// The product.
        /// </param>
        /// <returns>
        /// The <see cref="Product"/>.
        /// </returns>
        Product AddProduct(Product product);
    }
}