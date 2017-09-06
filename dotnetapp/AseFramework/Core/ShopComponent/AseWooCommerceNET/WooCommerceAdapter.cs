using System.Threading.Tasks;
using AseFramework.Core.ShopComponent;
using WooCommerceNET;
using WooCommerceNET.WooCommerce.v2;

namespace DotnetApp.AseFramework.Core.ShopComponent.AseWooCommerceNET
{
    public class WooCommerceAdapter : IShopAdapter
    {
        private RestAPI _restApi;

        public Product AddProduct(Product product)
        {
            var s = InternalAddProductTask(_restApi, product).Result;
            return s;
        }
        
        private static async Task<Product>
            InternalAddProductTask(RestAPI restApi, Product p)
        {
            //            var start = DateTime.Now;

            var wc = new WCObject(restApi);
            var res = await wc.Product.Add(p);
            //            var duration = DateTime.Now - start;
            //            Console.WriteLine($"duration to add product: {duration}");
            return res;
        }

        public void SetRestApi(RestAPI restApi)
        {
            _restApi = restApi;
        }
    }
}