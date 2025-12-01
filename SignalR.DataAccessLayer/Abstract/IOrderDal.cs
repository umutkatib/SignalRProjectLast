using SignalR.EntityLayer.Entitites;

namespace SignalR.DataAccessLayer.Abstract
{
	public interface IOrderDal : IGenericDal<Order>
	{
		public int TotalOrderCount();
		public int ActiveOrderCount();
		public decimal LastOrderPrice();
	}
}
