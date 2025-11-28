using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SignalRWebUI.Dtos.OpenHourDtos
{
	public class GetOpenHourDto
	{
		public int OpenHourID { get; set; }
		public string OpenHourDays { get; set; }
		public string OpenHourHours { get; set; }
	}
}
