using Microsoft.EntityFrameworkCore;
using SignalR.DataAccessLayer.Abstract;
using SignalR.DataAccessLayer.Concrete;
using SignalR.DataAccessLayer.Repositories;
using SignalR.EntityLayer.Entitites;
using System.ComponentModel;

namespace SignalR.DataAccessLayer.EntityFramework
{
	public class EfProductDal : GenericRepository<Product>, IProductDal
	{
		public EfProductDal(SignalRContext context) : base(context)
		{
		}

		public List<Product> GetProductsWithCategories()
		{
			var context = new SignalRContext();
			var values = context.Products.Include(x => x.Category).ToList();
			return values;
		}

		public int ProductCount()
		{
			using var context = new SignalRContext();
			return context.Products.Count();
		}

		public int ProductCountByCategoryNameHamburger()
		{
			var context = new SignalRContext();
			return context.Products.Where(x => x.CategoryID ==
			(context.Categories.Where(y => y.CategoryName == "Burgerler").Select(z => z.CategoryID).FirstOrDefault())).Count();
		}
		public int ProductCountByCategoryNameDrink()
		{
			var context = new SignalRContext();
			return context.Products.Where(x => x.CategoryID ==
			(context.Categories.Where(y => y.CategoryName == "İçecekler").Select(z => z.CategoryID).FirstOrDefault())).Count();
		}

		public decimal ProductPriceByAvg()
		{
			var context = new SignalRContext();
			return context.Products.Average(x => x.ProductPrice);
		}

		public string ProductNamePriceByMax()
		{
			var context = new SignalRContext();
			return context.Products.Where(x => x.ProductPrice == (context.Products.Max(y => y.ProductPrice))).Select(z => z.ProductName).FirstOrDefault();
		}

		public string ProductNamePriceByMin()
		{
			var context = new SignalRContext();
			return context.Products.Where(x => x.ProductPrice == (context.Products.Min(y => y.ProductPrice))).Select(z => z.ProductName).FirstOrDefault();
		}

		public decimal ProductAvgPriceByHamburger()
		{
			var context = new SignalRContext();
			return context.Products.Where(x => x.CategoryID == 
					(context.Categories.Where(y => y.CategoryName == "Burgerler")
					.Select(z => z.CategoryID).FirstOrDefault())).Average(t => t.ProductPrice);
		}
	}
}
