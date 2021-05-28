using System;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace Model
{
	[Serializable]
	public class Movie
	{
		/// <summary>
		/// 影片编号
		/// </summary>
		[Required]
		[DisplayName("影片编号")]
		public int MovieId { get; set; }

		/// <summary>
		/// 电影名称
		/// </summary>
		[DisplayName("电影名称")]
		public string MovieName { get; set; }

		/// <summary>
		/// 宣传海报
		/// </summary>
		[DisplayName("宣传海报")]
		public string Poster { get; set; }

		/// <summary>
		/// 导演
		/// </summary>
		[DisplayName("导演")]
		public string Director { get; set; }

		/// <summary>
		/// 主演
		/// </summary>
		[DisplayName("主演")]
		public string Actor { get; set; }

		/// <summary>
		/// 影片类型
		/// </summary>
		[DisplayName("影片类型")]
		public string MovieType { get; set; }

		/// <summary>
		/// 时长
		/// </summary>
		[DisplayName("时长")]
		public string Duration { get; set; }

		/// <summary>
		/// 价格
		/// </summary>
		[DisplayName("价格")]
		public string Price { get; set; }

		/// <summary>
		/// 是否上映
		/// </summary>
		[DisplayName("是否上映")]
		public bool? IsTop { get; set; }

	}
}
