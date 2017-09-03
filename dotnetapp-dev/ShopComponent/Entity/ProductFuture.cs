#region

#endregion

namespace DotnetApp.ShopComponent.Entity
{
    using WooCommerceNET.WooCommerce.v2;

    public class ProductFuture
    {
        private Product _container;

        public ProductFuture()
        {
            this._container = new Product();
        }
    }
}