// --------------------------------------------------------------------------------------------------------------------
// <copyright file="IShopConfiguration.cs" company="">
//   
// </copyright>
// <summary>
//   The ShopConfiguration interface.
// </summary>
// --------------------------------------------------------------------------------------------------------------------

namespace DotnetApp.ShopComponent
{
    /// <summary>
    /// The ShopConfiguration interface.
    /// </summary>
    public interface IShopConfiguration
    {
        /// <summary>
        /// The configure.
        /// </summary>
        /// <param name="adapter">
        /// The adapter.
        /// </param>
        void Configure(IShopAdapter adapter);
    }
}