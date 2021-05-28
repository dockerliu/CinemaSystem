using System;
using System.Collections.Generic;
using System.Text;

namespace BLL
{
	public class TicketManager
	{
		private DAL.TicketService dataTicket;
		public TicketManager()
		{
			this.dataTicket = new DAL.TicketService();
		}
		/// <summary>
		/// 新增
		/// </summary>
		public int Add(Model.Ticket model)
		{
			return dataTicket.Add(model);
		}
		/// <summary>
		/// 更新
		/// </summary>
		public int Update(Model.Ticket model)
		{
			return dataTicket.Update(model);
		}
		/// <summary>
		/// 查询所有记录
		/// </summary>
		public List<Model.Ticket> GetAll()
		{
			return dataTicket.GetAll();
		}
		/// <summary>
		/// 查询单条记录
		/// </summary>
		public Model.Ticket Get(int ticketid)
		{
			return dataTicket.Get(ticketid);
		}
		/// <summary>
		/// 删除
		/// </summary>
		public int Delete(int ticketid)
		{
			return dataTicket.Delete(ticketid);
		}
		/// <summary>
		/// 查询记录条数
		/// </summary>
		public long GetCount()
		{
			return dataTicket.GetCount();
		}
	}
}
