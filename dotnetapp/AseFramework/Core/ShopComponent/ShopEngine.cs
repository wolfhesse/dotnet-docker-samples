#region using directives

using WooCommerceNET.WooCommerce.v2;

#endregion

namespace AseFramework.Core.ShopComponent
{
  public class ShopEngine
  {
    public ShopEngine(IShopAdapter adapter, IShopConfiguration configuration)
    {
      Adapter = adapter;
      Configuration = configuration;
      configuration.Configure(adapter);
    }

    private ShopEngine()
    {
    }

    public  IShopAdapter Adapter { get; private set; }

    private IShopConfiguration Configuration { get; }

    public Product AddProduct(Product product)
    {
      return DotnetApp.AseFramework.Core.ShopComponent.AseWooCommerceNET.UseCases.AddProduct.Execute(this.Adapter, product);
    }
  }
}