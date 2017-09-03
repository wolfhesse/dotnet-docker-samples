namespace DotnetApp.AseFramework.Core.ShopComponent.AseWooCommerceNET.UseCases
{
    #region using directives

    using System.Collections.Generic;
    using System.Threading.Tasks;

    using WooCommerceNET;
    using WooCommerceNET.WooCommerce.v2;

    #endregion

    /// <summary>
    ///     The get products base.
    /// </summary>
    public abstract class GetProductsBase : IGetProducts
    {
        /// <summary>
        ///     The exec get products.
        /// </summary>
        /// <param name="pPage">
        ///     The p page.
        /// </param>
        /// <param name="pPerPage">
        ///     The p per page.
        /// </param>
        /// <param name="restApi">
        ///     The rest api.
        /// </param>
        /// <param name="pIncludeProductIds">
        ///     The p include product ids.
        /// </param>
        /// <returns>
        ///     The <see cref="Task" />.
        /// </returns>
        public async Task<List<Product>> ExecGetProducts(
            int pPage,
            int pPerPage,
            RestAPI restApi,
            string pIncludeProductIds = null)
        {
            var p = await GetProductViaApi.FnGetProductsByIncludePerPagePage(
                        pPage,
                        pPerPage,
                        restApi,
                        pIncludeProductIds);
            return p;
        }

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
        public List<Product> Execute(
            RestAPI restApi,
            int pPage = 1,
            int pPerPage = 10,
            string pIncludeProductIds = null)
        {
            var p = this.ExecGetProducts(pPage, pPerPage, restApi, pIncludeProductIds).Result;

            this.ProductListWrite(p);
            return p;
        }

        /// <summary>
        ///     The product list write.
        /// </summary>
        /// <param name="p">
        ///     The p.
        /// </param>
        public abstract void ProductListWrite(List<Product> p);
    }
}