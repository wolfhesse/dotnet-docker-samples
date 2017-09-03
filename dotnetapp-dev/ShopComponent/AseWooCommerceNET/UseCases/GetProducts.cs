#region

using System;
using System.Collections.Generic;
using ClassLibrary.ShopComponent.AseWooCommerceNET.UseCases;
using WooCommerceNET.WooCommerce.v2;

#endregion

namespace dotnetapp.ShopComponent.AseWooCommerceNET.UseCases
{
    #region

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