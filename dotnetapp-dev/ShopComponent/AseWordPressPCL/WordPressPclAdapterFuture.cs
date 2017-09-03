// --------------------------------------------------------------------------------------------------------------------
// <copyright file="WordPressPclAdapterFuture.cs" company="">
//   
// </copyright>
// <summary>
//   The word press pcl adapter future.
// </summary>
// --------------------------------------------------------------------------------------------------------------------

namespace DotnetApp.ShopComponent.AseWordPressPCL
{
    #region

    using System;

    using WooCommerceNET.WooCommerce.v2;

    #endregion

    /// <summary>
    /// The word press pcl adapter future.
    /// </summary>
    internal class WordPressPclAdapterFuture : IShopAdapter
    {
        // public Product AddProduct(Product product)
        // {
        // // Initialize
        // var client = new WordPressClient("http://wolfspool.at/wprcs2/wp-json/");
        // client.Username = "rogera";
        // client.Password = "1boris";
        // }
        /// <summary>
        /// The add product.
        /// </summary>
        /// <param name="product">
        /// The product.
        /// </param>
        /// <returns>
        /// The <see cref="Product"/>.
        /// </returns>
        /// <exception cref="NotImplementedException">
        /// </exception>
        public Product AddProduct(Product product)
        {
            throw new NotImplementedException();
        }
    }
}