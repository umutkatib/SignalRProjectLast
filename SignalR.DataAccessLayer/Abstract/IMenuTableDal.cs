using SignalR.EntityLayer.Entitites;

namespace SignalR.DataAccessLayer.Abstract
{
	public interface IMenuTableDal : IGenericDal<MenuTable>
	{
		public int MenuTableCount();
	}
}
