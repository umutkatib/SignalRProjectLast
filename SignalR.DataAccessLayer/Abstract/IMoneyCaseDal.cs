using SignalR.EntityLayer.Entitites;

namespace SignalR.DataAccessLayer.Abstract
{
	public interface IMoneyCaseDal : IGenericDal<MoneyCase>
	{
		public decimal TotalMoneyCaseAmount();
	}
}
