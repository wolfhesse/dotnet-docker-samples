#region using directives

using AseFramework.Core.ShopComponent;
using WooCommerceNET.WooCommerce.v2;

#endregion

namespace DotnetApp.AseFramework.Core.ShopComponent.AseWooCommerceNET.UseCases
{
  public class AddProduct
  {
    public static Product Execute(IShopAdapter adapter, Product p2)
    {
      return adapter.AddProduct(p2);
    }
  }
}