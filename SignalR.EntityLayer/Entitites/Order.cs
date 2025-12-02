using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
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
		[Column(TypeName = "Date")]
		public DateTime OrderDate { get; set; }
		public decimal OrderTotalPrice { get; set; }
		public bool OrderStatus { get; set; }
		public List<OrderDetail> OrderDetails { get; set; }
	}
}
