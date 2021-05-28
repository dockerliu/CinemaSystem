using System;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace Model
{
	[Serializable]
	public class Ticket
	{
		/// <summary>
		/// TicketID
		/// </summary>
		[Required]
		[DisplayName("TicketID")]
		public int TicketID { get; set; }

		/// <summary>
		/// ScheduleID
		/// </summary>
		[DisplayName("ScheduleID")]
		public int? ScheduleID { get; set; }

		/// <summary>
		/// 价格
		/// </summary>
		[Required]
		[DisplayName("价格")]
		public decimal Price { get; set; }

		/// <summary>
		/// 位置号
		/// </summary>
		[DisplayName("位置号")]
		public string SeatNo { get; set; }

		/// <summary>
		/// 创建时间
		/// </summary>
		[DisplayName("创建时间")]
		public DateTime? CreateTime { get; set; }

	}
}
