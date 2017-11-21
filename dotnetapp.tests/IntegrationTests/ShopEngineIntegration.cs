// --------------------------------------------------------------------------------------------------------------------
// <copyright file="ShopEngineIntegration.cs" company="">
//   
// </copyright>
// <summary>
//   The shop engine integration.
// </summary>
// --------------------------------------------------------------------------------------------------------------------

namespace DotnetApp.Tests.IntegrationTests
{
    #region using directives

    using System;
    using System.Collections.Generic;

    using DnsLib.AseFramework.Core.Components.ShopComponent;
    using DnsLib.AseFramework.Core.Components.ShopComponent.AseWooCommerceNET;
    using DnsLib.AseFramework.Core.Engines;

    using Microsoft.VisualStudio.TestTools.UnitTesting;

    

    using WooCommerceNET.WooCommerce.v2;

    

    #endregion

    /// <summary>The shop engine integration.</summary>
    /// 
    /// 
    [TestClass]
    public class ShopEngineIntegration
    {
        /// <summary>The create shop engine setup.</summary>
        [TestMethod()]
//        [MaxTime(10000)]
        public void CreateShopEngineSetup()
        {
            var shop1 = new ShopEngine(
                new WooCommerceAdapter(),
                new WooCommerceConfiguration(WooStuffAuthAdapter.FnRestApiRcs2()));
            shop1.AddProduct(
                new Product
                    {
                        name = $"/testing/ShopEngineIntegration/CreateShopEngineSetup @ {DateTimeOffset.Now}",
                        price = decimal.Parse("1"),
                        categories =
                            new List<ProductCategoryLine>
                                {
                                    new ProductCategoryLine
                                        {
                                            name =
                                                "x-ase-component-shop"
                                        },
                                    new ProductCategoryLine { name = "x-ase-test" },
                                    new ProductCategoryLine
                                        {
                                            name =
                                                "x-ase-integration"
                                        }
                                },
                        description = $"{DateTimeOffset.Now} description",
                        short_description = $"{DateTimeOffset.Now} short desc"
                    });
            Assert.IsNotNull(shop1);
        }
    }
}