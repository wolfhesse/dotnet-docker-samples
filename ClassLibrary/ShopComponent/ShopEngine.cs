using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WooCommerceNET.WooCommerce.v2;

namespace ClassLibrary.ShopComponent
{
    public class ShopEngine
    {
        public IShopConfiguration Configuration { get; }
        public IShopAdapter Adapter { get; }
        private ShopEngine() { }

        public ShopEngine(IShopAdapter adapter, IShopConfiguration configuration)
        {
            this.Adapter = adapter;
            this.Configuration = configuration;
            configuration.Configure(adapter);
        }

        public Product AddProduct(Product product) => Adapter.AddProduct(product);
    }
}
