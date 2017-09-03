namespace DotnetApp.AseFramework.Core.ShopComponent.AseWooCommerceNET
{
    #region using directives

    using System;

    using WooCommerceNET;

    #endregion

    /// <summary>
    ///     The woo commerce configuration.
    /// </summary>
    public class WooCommerceConfiguration : IShopConfiguration
    {
        /// <summary>
        ///     The _rest api.
        /// </summary>
        private readonly RestAPI _restApi;

        /// <summary>
        ///     Initializes a new instance of the <see cref="WooCommerceConfiguration" /> class.
        /// </summary>
        /// <param name="restApi">
        ///     The rest api.
        /// </param>
        public WooCommerceConfiguration(RestAPI restApi)
        {
            this._restApi = restApi;
        }

        /// <summary>
        ///     The configure.
        /// </summary>
        /// <param name="adapter">
        ///     The adapter.
        /// </param>
        /// <exception cref="Exception">
        /// </exception>
        public void Configure(IShopAdapter adapter)
        {
            if (adapter is WooCommerceAdapter sa) sa.SetRestApi(this._restApi);
            else
                throw new Exception(
                    "incompatible adapter: " + typeof(WooCommerceAdapter) + " for configuration: "
                    + typeof(WooCommerceConfiguration));
        }
    }
}