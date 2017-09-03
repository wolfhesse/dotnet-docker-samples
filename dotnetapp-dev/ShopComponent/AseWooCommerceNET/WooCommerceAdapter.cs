#region

#endregion

namespace DotnetApp.ShopComponent.AseWooCommerceNET
{
    using WooCommerceNET;
    using WooCommerceNET.WooCommerce.v2;

    public class WooCommerceAdapter : IShopAdapter
    {
        private RestAPI _restApi;

        public Product AddProduct(Product product)
        {
            var s = UseCases.AddProduct.Execute(this._restApi, product).Result;
            return s;
        }


        public void SetRestApi(RestAPI restApi)
        {
            this._restApi = restApi;
        }
    }
}