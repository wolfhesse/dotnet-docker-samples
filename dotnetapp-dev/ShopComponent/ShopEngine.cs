#region

using WooCommerceNET.WooCommerce.v2;

#endregion

namespace dotnetapp.ShopComponent
{
    public class ShopEngine
    {
        private ShopEngine()
        {
        }

        public ShopEngine(IShopAdapter adapter, IShopConfiguration configuration)
        {
            Adapter = adapter;
            Configuration = configuration;
            configuration.Configure(adapter);
        }

        public IShopConfiguration Configuration { get; }
        public IShopAdapter Adapter { get; }

        public Product AddProduct(Product product)
        {
            return Adapter.AddProduct(product);
        }
    }
}