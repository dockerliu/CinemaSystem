using System;
using System.Collections.Generic;
using System.Text;
using System.Data;
using MySql.Data.MySqlClient;

namespace DAL
{
	public class TicketService
	{
		private DbHelper dbHelper = new DbHelper();
		/// <summary>
		/// 构造函数
		/// </summary>
		public TicketService()
		{
		}
		/// <summary>
		/// 添加记录
		/// </summary>
		/// <param name="model">Model.Ticket实体类</param>
		/// <returns>操作所影响的行数</returns>
		public int Add(Model.Ticket model)
		{
			string sql = @"INSERT INTO Ticket
				(TicketID,ScheduleID,Price,SeatNo,CreateTime) 
				VALUES(@TicketID,@ScheduleID,@Price,@SeatNo,@CreateTime)";
			MySqlParameter[] parameters = new MySqlParameter[]{
				new MySqlParameter("@TicketID", MySqlDbType.Int32, 11){ Value = model.TicketID },
				model.ScheduleID == null ? new MySqlParameter("@ScheduleID", MySqlDbType.Int32, 11) { Value = DBNull.Value } : new MySqlParameter("@ScheduleID", MySqlDbType.Int32, 11) { Value = model.ScheduleID },
				new MySqlParameter("@Price", MySqlDbType.Decimal, -1){ Value = model.Price },
				model.SeatNo == null ? new MySqlParameter("@SeatNo", MySqlDbType.VarChar, 255) { Value = DBNull.Value } : new MySqlParameter("@SeatNo", MySqlDbType.VarChar, 255) { Value = model.SeatNo },
				model.CreateTime == null ? new MySqlParameter("@CreateTime", MySqlDbType.DateTime, -1) { Value = DBNull.Value } : new MySqlParameter("@CreateTime", MySqlDbType.DateTime, -1) { Value = model.CreateTime }
			};
			return dbHelper.Execute(sql, parameters);
		}
		/// <summary>
		/// 更新记录
		/// </summary>
		/// <param name="model">Model.Ticket实体类</param>
		public int Update(Model.Ticket model)
		{
			string sql = @"UPDATE Ticket SET 
				ScheduleID=@ScheduleID,Price=@Price,SeatNo=@SeatNo,CreateTime=@CreateTime
				WHERE TicketID=@TicketID";
			MySqlParameter[] parameters = new MySqlParameter[]{
				model.ScheduleID == null ? new MySqlParameter("@ScheduleID", MySqlDbType.Int32, 11) { Value = DBNull.Value } : new MySqlParameter("@ScheduleID", MySqlDbType.Int32, 11) { Value = model.ScheduleID },
				new MySqlParameter("@Price", MySqlDbType.Decimal, -1){ Value = model.Price },
				model.SeatNo == null ? new MySqlParameter("@SeatNo", MySqlDbType.VarChar, 255) { Value = DBNull.Value } : new MySqlParameter("@SeatNo", MySqlDbType.VarChar, 255) { Value = model.SeatNo },
				model.CreateTime == null ? new MySqlParameter("@CreateTime", MySqlDbType.DateTime, -1) { Value = DBNull.Value } : new MySqlParameter("@CreateTime", MySqlDbType.DateTime, -1) { Value = model.CreateTime },
				new MySqlParameter("@TicketID", MySqlDbType.Int32, 11){ Value = model.TicketID }
			};
			return dbHelper.Execute(sql, parameters);
		}
		/// <summary>
		/// 删除记录
		/// </summary>
		public int Delete(int ticketid)
		{
			string sql = "DELETE FROM Ticket WHERE TicketID=@TicketID";
			MySqlParameter[] parameters = new MySqlParameter[]{
				new MySqlParameter("@TicketID", MySqlDbType.Int32, 11){ Value = ticketid }
			};
			return dbHelper.Execute(sql, parameters);
		}
		/// <summary>
		/// 将DataRedar转换为List
		/// </summary>
		private List<Model.Ticket> DataReaderToList(MySqlDataReader dataReader)
		{
			List<Model.Ticket> List = new List<Model.Ticket>();
			Model.Ticket model = null;
			while(dataReader.Read())
			{
				model = new Model.Ticket();
				model.TicketID = dataReader.GetInt32(0);
				if (!dataReader.IsDBNull(1))
					model.ScheduleID = dataReader.GetInt32(1);
				model.Price = dataReader.GetDecimal(2);
				if (!dataReader.IsDBNull(3))
					model.SeatNo = dataReader.GetString(3);
				if (!dataReader.IsDBNull(4))
					model.CreateTime = dataReader.GetDateTime(4);
				List.Add(model);
			}
			return List;
		}
		/// <summary>
		/// 查询所有记录
		/// </summary>
		public List<Model.Ticket> GetAll()
		{
			string sql = "SELECT * FROM Ticket";
			MySqlDataReader dataReader = dbHelper.GetDataReader(sql);
			List<Model.Ticket> List = DataReaderToList(dataReader);
			dataReader.Close();
			return List;
		}
		/// <summary>
		/// 查询记录数
		/// </summary>
		public long GetCount()
		{
			string sql = "SELECT COUNT(*) FROM Ticket";
			long count;
			return long.TryParse(dbHelper.GetFieldValue(sql), out count) ? count : 0;
		}
		/// <summary>
		/// 根据主键查询一条记录
		/// </summary>
		public Model.Ticket Get(int ticketid)
		{
			string sql = "SELECT * FROM Ticket WHERE TicketID=@TicketID";
			MySqlParameter[] parameters = new MySqlParameter[]{
				new MySqlParameter("@TicketID", MySqlDbType.Int32, 11){ Value = ticketid }
			};
			MySqlDataReader dataReader = dbHelper.GetDataReader(sql, parameters);
			List<Model.Ticket> List = DataReaderToList(dataReader);
			dataReader.Close();
			return List.Count > 0 ? List[0] : null;
		}
	}
}