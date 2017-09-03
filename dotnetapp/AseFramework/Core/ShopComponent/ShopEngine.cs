namespace DotnetApp.AseFramework.Core.ShopComponent
{
    #region using directives

    using WooCommerceNET.WooCommerce.v2;

    #endregion

    /// <summary>
    ///     The shop engine.
    /// </summary>
    public class ShopEngine
    {
        /// <summary>
        ///     Initializes a new instance of the <see cref="ShopEngine" /> class.
        /// </summary>
        /// <param name="adapter">
        ///     The adapter.
        /// </param>
        /// <param name="configuration">
        ///     The configuration.
        /// </param>
        public ShopEngine(IShopAdapter adapter, IShopConfiguration configuration)
        {
            this.Adapter = adapter;
            this.Configuration = configuration;
            configuration.Configure(adapter);
        }

        // ReSharper disable once UnusedMember.Local
        /// <summary>
        ///     Prevents a default instance of the <see cref="ShopEngine" /> class from being created.
        /// </summary>
        private ShopEngine()
        {
        }

        /// <summary>
        ///     Gets the adapter.
        /// </summary>
        public IShopAdapter Adapter { get; }

        /// <summary>
        ///     Gets the configuration.
        /// </summary>
        public IShopConfiguration Configuration { get; }

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
            return this.Adapter.AddProduct(product);
        }
    }
}