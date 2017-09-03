#region

#endregion

namespace DotnetApp.ShopComponent.AseWooCommerceNET
{
    using System;

    using WooCommerceNET;

    public class WooCommerceConfiguration : IShopConfiguration
    {
        private readonly RestAPI _restApi;

        public WooCommerceConfiguration(RestAPI restApi)
        {
            this._restApi = restApi;
        }

        public void Configure(IShopAdapter adapter)
        {
            if (adapter is WooCommerceAdapter sa)
                sa.SetRestApi(this._restApi);
            else
                throw new Exception(
                    "incompatible adapter: "
                    + typeof(WooCommerceAdapter)
                    + " for configuration: "
                    + typeof(WooCommerceConfiguration));
        }
    }
}