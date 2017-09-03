using System;
using WooCommerceNET;

namespace ClassLibrary.ShopComponent.AseWooCommerceNET
{
    public class WooCommerceConfiguration : IShopConfiguration
    {
        private readonly RestAPI _restApi;

        public WooCommerceConfiguration(RestAPI restApi)
        {
            _restApi = restApi;
        }

        public void Configure(IShopAdapter adapter)
        {
            var sa = adapter as WooCommerceAdapter;
            if (null != sa)
                sa.SetRestApi(_restApi);
            else
                throw new Exception(
                    "incompatible adapter: "
                    + typeof(WooCommerceAdapter)
                    + " for configuration: "
                    + typeof(WooCommerceConfiguration));
        }
    }
}