using SignalR.EntityLayer.Entitites;

namespace SignalR.BusinessLayer.Abstract
{
	public interface IMenuTableService : IGenericService<MenuTable>
	{
		public int TMenuTableCount();

	}
}
