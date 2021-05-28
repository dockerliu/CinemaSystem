using System;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace Model
{
	[Serializable]
	public class Schedule
	{
		/// <summary>
		/// 计划编号
		/// </summary>
		[Required]
		[DisplayName("计划编号")]
		public int ID { get; set; }

		/// <summary>
		/// 影片编号
		/// </summary>
		[DisplayName("影片编号")]
		public int? MovieID { get; set; }

		/// <summary>
		/// 放映厅编号
		/// </summary>
		[DisplayName("放映厅编号")]
		public int? HallID { get; set; }

		/// <summary>
		/// 放映时间
		/// </summary>
		[DisplayName("放映时间")]
		public DateTime? PlayTime { get; set; }

		/// <summary>
		/// 折扣
		/// </summary>
		[DisplayName("折扣")]
		public string Discount { get; set; }

	}
}
