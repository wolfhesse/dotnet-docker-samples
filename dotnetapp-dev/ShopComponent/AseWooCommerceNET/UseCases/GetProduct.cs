#region

using System.Collections.Generic;
using System.Threading.Tasks;
using WooCommerceNET;
using WooCommerceNET.WooCommerce.v2;

#endregion

namespace dotnetapp.ShopComponent.AseWooCommerceNET.UseCases
{
    public class GetProduct
    {
        public static async Task<Product>
            Execute(string pId, RestAPI restApi)
        {
            var p = await FnGetProductsById(pId, restApi);
            return p;
        }

        public static async Task<List<Product>>
            FnGetProductsByIncludePerPagePage(string pPage,
                string pPerPage, RestAPI restApi, string pIncludeProductIds = null)
        {
            var wc = new WCObject(restApi);

            var dictionary = new Dictionary<string, string>
            {
//                {"include", pIncludeProductIds},
                {"per_page", pPerPage},
                {"page", pPage}
            };
            if (null != pIncludeProductIds) dictionary["include"] = pIncludeProductIds;

            var p = await wc.Product.GetAll(dictionary);
            return p;
        }


        public static async Task<Product>
            FnGetProductsById(string pId, RestAPI restApi)
        {
            var wc = new WCObject(restApi);
            var p = await wc.Product.GetAll(new Dictionary<string, string>
            {
                {"include", pId}
            });

            return 0 < p.Count ? p[0] : new Product();
        }
    }
}