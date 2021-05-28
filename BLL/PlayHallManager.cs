using System;
using System.Collections.Generic;
using System.Text;

namespace BLL
{
	public class PlayHallManager
	{
		private DAL.PlayHallService dataPlayHall;
		public PlayHallManager()
		{
			this.dataPlayHall = new DAL.PlayHallService();
		}
		/// <summary>
		/// 新增
		/// </summary>
		public int Add(Model.PlayHall model)
		{
			return dataPlayHall.Add(model);
		}
		/// <summary>
		/// 更新
		/// </summary>
		public int Update(Model.PlayHall model)
		{
			return dataPlayHall.Update(model);
		}
		/// <summary>
		/// 查询所有记录
		/// </summary>
		public List<Model.PlayHall> GetAll()
		{
			return dataPlayHall.GetAll();
		}
		/// <summary>
		/// 查询单条记录
		/// </summary>
		public Model.PlayHall Get(int hallid)
		{
			return dataPlayHall.Get(hallid);
		}
		/// <summary>
		/// 删除
		/// </summary>
		public int Delete(int hallid)
		{
			return dataPlayHall.Delete(hallid);
		}
		/// <summary>
		/// 查询记录条数
		/// </summary>
		public long GetCount()
		{
			return dataPlayHall.GetCount();
		}
	}
}
