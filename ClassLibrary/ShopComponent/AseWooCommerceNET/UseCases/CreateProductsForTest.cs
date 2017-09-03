using System;
using WooCommerceNET;
using WooCommerceNET.WooCommerce.v2;

namespace ClassLibrary.ShopComponent.AseWooCommerceNET.UseCases
{
    public class CreateProductsForTest
    {
        public static void
            Execute(RestAPI restApi, int HowMany = 3)
        {
            ShopEngine shopEngine = new ShopEngine(
                new WooCommerceAdapter(),
                configuration: new WooCommerceConfiguration(restApi)
            );

            var p2 = new Product
            {
                description = $"test product from {typeof(AddProduct)}",
                price = 8.0M
            };

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