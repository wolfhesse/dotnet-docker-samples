#region using directives

using System.Threading.Tasks;
using WooCommerceNET;
using WooCommerceNET.WooCommerce.v2;

#endregion

namespace DotnetApp.AseFramework.Core.ShopComponent.AseWooCommerceNET.UseCases
{
    #region using directives

    #endregion

    /// <summary>
    ///     The add product.
    /// </summary>
    public class AddProduct
    {
        /// <summary>
        ///     The execute.
        /// </summary>
        /// <param name="restApi">
        ///     The rest api.
        /// </param>
        /// <param name="p2">
        ///     The p 2.
        /// </param>
        /// <returns>
        ///     The <see cref="Task" />.
        /// </returns>
        public static async Task<Product> Execute(RestAPI restApi, Product p2)
        {
            return await FnPostProduct(restApi, p2);
        }

        /// <summary>
        ///     The fn post product.
        /// </summary>
        /// <param name="restApi">
        ///     The rest api.
        /// </param>
        /// <param name="p">
        ///     The p.
        /// </param>
        /// <returns>
        ///     The <see cref="Task" />.
        /// </returns>
        public static async Task<Product> FnPostProduct(RestAPI restApi, Product p)
        {
            // var start = DateTime.Now;
            var wc = new WCObject(restApi);
            var res = await wc.Product.Add(p);

            // var duration = DateTime.Now - start;
            // Console.WriteLine($"duration to add product: {duration}");
            return res;
        }
    }
}