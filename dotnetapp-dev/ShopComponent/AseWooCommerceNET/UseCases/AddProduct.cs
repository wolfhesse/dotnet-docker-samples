#region

using System.Threading.Tasks;
using WooCommerceNET;
using WooCommerceNET.WooCommerce.v2;

#endregion

namespace dotnetapp.ShopComponent.AseWooCommerceNET.UseCases
{
    public class AddProduct
    {
        public static async Task<Product> Execute(RestAPI restApi, Product p2)
        {
            return await FnPostProduct(restApi, p2);
        }

        public static async Task<Product>
            FnPostProduct(RestAPI restApi, Product p)
        {
//            var start = DateTime.Now;

            var wc = new WCObject(restApi);
            var res = await wc.Product.Add(p);
//            var duration = DateTime.Now - start;
//            Console.WriteLine($"duration to add product: {duration}");
            return res;
        }
    }
}