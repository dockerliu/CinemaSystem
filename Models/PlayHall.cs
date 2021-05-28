using System;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace Model
{
	[Serializable]
	public class PlayHall
	{
		/// <summary>
		/// 放映厅编号
		/// </summary>
		[Required]
		[DisplayName("放映厅编号")]
		public int HallId { get; set; }

		/// <summary>
		/// 放映厅名字
		/// </summary>
		[DisplayName("放映厅名字")]
		public string HallName { get; set; }

		/// <summary>
		/// 座位列表
		/// </summary>
		[DisplayName("座位列表")]
		public string SeatList { get; set; }

		/// <summary>
		/// 是否有效
		/// </summary>
		[DisplayName("是否有效")]
		public bool? IsValid { get; set; }

	}
}
