// --------------------------------------------------------------------------------------------------------------------
// <copyright file="CreateProductsForTest.cs" company="">
//   
// </copyright>
// <summary>
//   The create products for test.
// </summary>
// --------------------------------------------------------------------------------------------------------------------

namespace DotnetApp.ShopComponent.AseWooCommerceNET.UseCases
{
    #region

    using System;

    using WooCommerceNET;
    using WooCommerceNET.WooCommerce.v2;

    #endregion

    /// <summary>
    /// The create products for test.
    /// </summary>
    public class CreateProductsForTest
    {
        /// <summary>
        /// The execute.
        /// </summary>
        /// <param name="restApi">
        /// The rest api.
        /// </param>
        /// <param name="HowMany">
        /// The how many.
        /// </param>
        public static void Execute(RestAPI restApi, int HowMany = 3)
        {
            var shopEngine = new ShopEngine(new WooCommerceAdapter(), new WooCommerceConfiguration(restApi));

            var p2 = new Product { description = $"test product from {typeof(AddProduct)}", price = 8.0M };

            for (var i = 0; i < HowMany; i++)
            {
                p2.name = $"test product {DateTimeOffset.Now.LocalDateTime}";
                p2.short_description = $@"testing {i}-of-{HowMany}";
                var s = shopEngine.AddProduct(p2);
                Console.Out.WriteLine(
                    $"{DateTimeOffset.Now}/{DateTimeOffset.Now.LocalDateTime.Millisecond} -> Product: {s}");
            }
        }
    }
}