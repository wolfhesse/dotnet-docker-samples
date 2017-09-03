using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using WooCommerceNET;
using WooCommerceNET.WooCommerce.v2;

namespace ClassLibrary.ShopComponent.AseWooCommerceNET.UseCases
{
    public class GetProducts
    {
        public static List<Product> Execute(RestAPI restApi, string pPage, string pPerPage,
                string pIncludeProductIds = null)
        {
            var p = ExecGetProducts(pPage, pPerPage, restApi,
                    pIncludeProductIds)
                .Result;

            FnLogging(p);
            return p;
        }

        private static void FnLogging(List<Product> p)
        {
            Console.Out.WriteLine($"{DateTimeOffset.Now} action: fetched {p.Count} products in {typeof(GetProducts)}\n\n");
            p.ForEach(
                px => { Console.Out.WriteLine($"\tproduct: {px.id}, {px.name}\n\t\t .. {px.short_description}"); });
        }

        public static async Task<List<Product>>
            ExecGetProducts(string pPage, string pPerPage, RestAPI restApi,
                string pIncludeProductIds = null)
        {
            var p = await GetProduct.FnGetProductsByIncludePerPagePage(pPage, pPerPage, restApi, pIncludeProductIds);
            return p;
        }
    }
}