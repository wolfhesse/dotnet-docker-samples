#region using directives

using System.Collections.Generic;
using System.Threading.Tasks;
using WooCommerceNET;
using WooCommerceNET.WooCommerce.v2;

#endregion

namespace DotnetApp.AseFramework.Core.ShopComponent.AseWooCommerceNET.UseCases
{
    #region using directives

    #endregion

    /// <summary>
    ///     The get product via api.
    /// </summary>
    public class GetProductViaApi
    {
        /// <summary>
        ///     The execute.
        /// </summary>
        /// <param name="pId">
        ///     The p id.
        /// </param>
        /// <param name="restApi">
        ///     The rest api.
        /// </param>
        /// <returns>
        ///     The <see cref="Task" />.
        /// </returns>
        public static async Task<Product> Execute(string pId, RestAPI restApi)
        {
            var p = await FnGetProductsById(pId, restApi);
            return p;
        }

        /// <summary>
        ///     The fn get products by id.
        /// </summary>
        /// <param name="pId">
        ///     The p id.
        /// </param>
        /// <param name="restApi">
        ///     The rest api.
        /// </param>
        /// <returns>
        ///     The <see cref="Task" />.
        /// </returns>
        public static async Task<Product> FnGetProductsById(string pId, RestAPI restApi)
        {
            var wc = new WCObject(restApi);
            var p = await wc.Product.GetAll(new Dictionary<string, string> {{"include", pId}});

            return 0 < p.Count ? p[0] : new Product();
        }

        /// <summary>
        ///     The fn get products by include per page page.
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
        public static async Task<List<Product>> FnGetProductsByIncludePerPagePage(
            int pPage,
            int pPerPage,
            RestAPI restApi,
            string pIncludeProductIds = null)
        {
            var wc = new WCObject(restApi);

            var dictionary = new Dictionary<string, string>
            {
                {"per_page", pPerPage.ToString()},
                {"page", pPage.ToString()}

                // {"include", pIncludeProductIds},
            };
            if (null != pIncludeProductIds) dictionary["include"] = pIncludeProductIds;

            var p = await wc.Product.GetAll(dictionary);
            return p;
        }
    }
}