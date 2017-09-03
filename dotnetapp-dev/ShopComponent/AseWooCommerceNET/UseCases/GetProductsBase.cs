namespace DotnetApp.ShopComponent.AseWooCommerceNET.UseCases
{
    using System.Collections.Generic;
    using System.Threading.Tasks;

    using WooCommerceNET;
    using WooCommerceNET.WooCommerce.v2;

    /// <summary>
    ///     The get products base.
    /// </summary>
    public abstract class GetProductsBase : IGetProducts
    {
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

        public abstract void ProductListWrite(List<Product> p);
    }
}