using System;
using AseFramework.Core.ShopComponent;
using WooCommerceNET;

namespace DotnetApp.AseFramework.Core.ShopComponent.AseWooCommerceNET
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
            if (adapter is WooCommerceAdapter sa)
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