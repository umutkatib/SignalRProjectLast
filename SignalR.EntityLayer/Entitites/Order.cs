using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SignalR.EntityLayer.Entitites
{
	public class Order
	{
		public int OrderID { get; set; }
		public string OrderTableNumber { get; set; }
		public string OrderTableDescription { get; set; }
		public DateTime OrderDate { get; set; }
		public decimal OrderTotalPrice { get; set; }
		public bool OrderStatus { get; set; }
		public List<OrderDetail> OrderDetails { get; set; }
	}
}
