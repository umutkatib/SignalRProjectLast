using SignalR.EntityLayer.Entitites;

namespace SignalR.DataAccessLayer.Abstract
{
	public interface IProductDal : IGenericDal<Product>
	{
		List<Product> GetProductsWithCategories();
		public int ProductCount();
		public int ProductCountByCategoryNameHamburger();
		public int ProductCountByCategoryNameDrink();
		public decimal ProductPriceByAvg();
		public string ProductNamePriceByMax();
		public string ProductNamePriceByMin();
		public decimal ProductAvgPriceByHamburger();
	}
}
