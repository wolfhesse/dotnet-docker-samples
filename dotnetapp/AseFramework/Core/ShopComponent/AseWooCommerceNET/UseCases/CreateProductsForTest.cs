#region using directives

using System;
using WooCommerceNET;
using WooCommerceNET.WooCommerce.v2;

#endregion

namespace DotnetApp.AseFramework.Core.ShopComponent.AseWooCommerceNET.UseCases
{
    #region using directives

    #endregion

    /// <summary>
    ///     The create products for test.
    /// </summary>
    public class CreateProductsForTest
    {
        /// <summary>
        ///     The execute.
        /// </summary>
        /// <param name="restApi">
        ///     The rest api.
        /// </param>
        /// <param name="howMany">
        ///     The how many.
        /// </param>
        public static void Execute(RestAPI restApi, int howMany = 3)
        {
            var shopEngine = new ShopEngine(new WooCommerceAdapter(), new WooCommerceConfiguration(restApi));

            var p2 = new Product {description = $"test product from {typeof(AddProduct)}", price = 8.0M};

            for (var i = 0; i < howMany; i++)
            {
                p2.name = $"test product {DateTimeOffset.Now.LocalDateTime}";
                p2.short_description = $@"testing {i}-of-{howMany}";
                var s = shopEngine.AddProduct(p2);
                Console.Out.WriteLine(
                    $"{DateTimeOffset.Now}/{DateTimeOffset.Now.LocalDateTime.Millisecond} -> Product: {s}");
            }
        }
    }
}