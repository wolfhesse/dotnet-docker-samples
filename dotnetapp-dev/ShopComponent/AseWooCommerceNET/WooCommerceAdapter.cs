#region

using WooCommerceNET;
using WooCommerceNET.WooCommerce.v2;

#endregion

namespace dotnetapp.ShopComponent.AseWooCommerceNET
{
    public class WooCommerceAdapter : IShopAdapter
    {
        private RestAPI _restApi;

        public Product AddProduct(Product product)
        {
            var s = UseCases.AddProduct.Execute(_restApi, product).Result;
            return s;
        }


        public void SetRestApi(RestAPI restApi)
        {
            _restApi = restApi;
        }
    }
}