#region using directives

using System;
using System.Collections.Generic;
using WooCommerceNET.WooCommerce.v2;

#endregion

namespace DotnetApp.AseFramework.Core.ShopComponent.AseWooCommerceNET.UseCases
{
    #region using directives

    #endregion

    /// <summary>
    ///     The get products.
    /// </summary>
    public class GetProducts : GetProductsBase
    {
        /// <summary>
        ///     The product list write.
        /// </summary>
        /// <param name="p">
        ///     The p.
        /// </param>
        public override void ProductListWrite(List<Product> p)
        {
            Console.Out.WriteLine(
                $"{DateTimeOffset.Now} action: fetched {p.Count} products in {typeof(IGetProducts)}\n\n");
            p.ForEach(
                px => { Console.Out.WriteLine($"\tproduct: {px.id}, {px.name}\n\t\t .. {px.short_description}"); });
        }
    }
}