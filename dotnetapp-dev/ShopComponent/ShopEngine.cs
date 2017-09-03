#region

#endregion

namespace DotnetApp.ShopComponent
{
    using WooCommerceNET.WooCommerce.v2;

    public class ShopEngine
    {
        // ReSharper disable once UnusedMember.Local
        private ShopEngine()
        {
        }

        public ShopEngine(IShopAdapter adapter, IShopConfiguration configuration)
        {
            this.Adapter = adapter;
            this.Configuration = configuration;
            configuration.Configure(adapter);
        }

        public IShopConfiguration Configuration { get; }
        public IShopAdapter Adapter { get; }

        public Product AddProduct(Product product)
        {
            return this.Adapter.AddProduct(product);
        }
    }
}