namespace DotnetApp.AseFramework.Core.ShopComponent.Entity
{
    #region using directives

    using WooCommerceNET.WooCommerce.v2;

    #endregion

    /// <summary>
    ///     The product future.
    /// </summary>
    public class ProductFuture
    {
        /// <summary>
        ///     The _container.
        /// </summary>
        private Product _container;

        /// <summary>
        ///     Initializes a new instance of the <see cref="ProductFuture" /> class.
        /// </summary>
        public ProductFuture()
        {
            this._container = new Product();
        }
    }
}