using SignalR.EntityLayer.Entitites;

namespace SignalR.BusinessLayer.Abstract
{
	public interface IMoneyCaseService : IGenericService<MoneyCase>
	{
		public decimal TTotalMoneyCaseAmount();
	}
}
