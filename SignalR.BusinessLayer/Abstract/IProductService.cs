using SignalR.EntityLayer.Entitites;

namespace SignalR.BusinessLayer.Abstract
{
	public interface IProductService : IGenericService<Product>
	{
		List<Product> TGetProductsWithCategories();
		public int TProductCount();
		public int TProductCountByCategoryNameHamburger();
		public int TProductCountByCategoryNameDrink();
		public decimal TProductPriceByAvg();
		public string TProductNamePriceByMax();
		public string TProductNamePriceByMin();
		public decimal TProductAvgPriceByHamburger();

	}
}
