using System;
using System.Collections.Generic;
using System.Text;

namespace BLL
{
	public class ScheduleManager
	{
		private DAL.ScheduleService dataSchedule;
		public ScheduleManager()
		{
			this.dataSchedule = new DAL.ScheduleService();
		}
		/// <summary>
		/// 新增
		/// </summary>
		public int Add(Model.Schedule model)
		{
			return dataSchedule.Add(model);
		}
		/// <summary>
		/// 更新
		/// </summary>
		public int Update(Model.Schedule model)
		{
			return dataSchedule.Update(model);
		}
		/// <summary>
		/// 查询所有记录
		/// </summary>
		public List<Model.Schedule> GetAll()
		{
			return dataSchedule.GetAll();
		}
		/// <summary>
		/// 查询所有上映电影记录
		/// </summary>
		public List<Model.Schedule> GetAllSchedule()
		{
			return dataSchedule.GetAllSchedule();
		}
		/// <summary>
		/// 查询单条记录
		/// </summary>
		public Model.Schedule Get(int id)
		{
			return dataSchedule.Get(id);
		}
		/// <summary>
		/// 删除
		/// </summary>
		public int Delete(int id)
		{
			return dataSchedule.Delete(id);
		}
		/// <summary>
		/// 查询记录条数
		/// </summary>
		public long GetCount()
		{
			return dataSchedule.GetCount();
		}
	}
}
