namespace DotnetApp.AseFramework.Core.ShopComponent.AseWooCommerceNET.UseCases
{
    #region using directives

    using System.Collections.Generic;

    using WooCommerceNET;
    using WooCommerceNET.WooCommerce.v2;

    #endregion

    /// <summary>
    ///     The GetProducts interface.
    /// </summary>
    public interface IGetProducts
    {
        /// <summary>
        ///     The execute.
        /// </summary>
        /// <param name="restApi">
        ///     The rest api.
        /// </param>
        /// <param name="pPage">
        ///     The p page.
        /// </param>
        /// <param name="pPerPage">
        ///     The p per page.
        /// </param>
        /// <param name="pIncludeProductIds">
        ///     The p include product ids.
        /// </param>
        /// <returns>
        ///     The <see cref="List" />.
        /// </returns>
        List<Product> Execute(RestAPI restApi, int pPage = 1, int pPerPage = 10, string pIncludeProductIds = null);
    }
}