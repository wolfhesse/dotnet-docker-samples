namespace DotnetApp.AseFramework.Core.ShopComponent
{
    /// <summary>
    ///     The ShopConfiguration interface.
    /// </summary>
    public interface IShopConfiguration
    {
        /// <summary>
        ///     The configure.
        /// </summary>
        /// <param name="adapter">
        ///     The adapter.
        /// </param>
        void Configure(IShopAdapter adapter);
    }
}