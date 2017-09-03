namespace DotnetApp.AseFramework.Core.ShopComponent.AseWooCommerceNET
{
    #region using directives

    using WooCommerceNET;
    using WooCommerceNET.WooCommerce.v2;

    #endregion

    /// <summary>
    ///     The woo commerce adapter.
    /// </summary>
    public class WooCommerceAdapter : IShopAdapter
    {
        /// <summary>
        ///     The _rest api.
        /// </summary>
        private RestAPI _restApi;

        /// <summary>
        ///     The add product.
        /// </summary>
        /// <param name="product">
        ///     The product.
        /// </param>
        /// <returns>
        ///     The <see cref="Product" />.
        /// </returns>
        public Product AddProduct(Product product)
        {
            var s = UseCases.AddProduct.Execute(this._restApi, product).Result;
            return s;
        }

        /// <summary>
        ///     The set rest api.
        /// </summary>
        /// <param name="restApi">
        ///     The rest api.
        /// </param>
        public void SetRestApi(RestAPI restApi)
        {
            this._restApi = restApi;
        }
    }
}