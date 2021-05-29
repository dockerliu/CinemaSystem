using System;
using System.Collections.Generic;
using System.Text;
using System.Data;
using MySql.Data.MySqlClient;

namespace DAL
{
	public class ScheduleService
	{
		private DbHelper dbHelper = new DbHelper();
		/// <summary>
		/// 构造函数
		/// </summary>
		public ScheduleService()
		{
		}
		/// <summary>
		/// 添加记录
		/// </summary>
		/// <param name="model">Model.Schedule实体类</param>
		/// <returns>新增记录的ID</returns>
		public int Add(Model.Schedule model)
		{
			string sql = @"INSERT INTO Schedule
				(MovieID,HallID,PlayTime,Discount) 
				VALUES(@MovieID,@HallID,@PlayTime,@Discount);
				SELECT LAST_INSERT_ID();";
			MySqlParameter[] parameters = new MySqlParameter[]{
				model.MovieID == null ? new MySqlParameter("@MovieID", MySqlDbType.Int32, 11) { Value = DBNull.Value } : new MySqlParameter("@MovieID", MySqlDbType.Int32, 11) { Value = model.MovieID },
				model.HallID == null ? new MySqlParameter("@HallID", MySqlDbType.Int32, 255) { Value = DBNull.Value } : new MySqlParameter("@HallID", MySqlDbType.Int32, 255) { Value = model.HallID },
				model.PlayTime == null ? new MySqlParameter("@PlayTime", MySqlDbType.DateTime, -1) { Value = DBNull.Value } : new MySqlParameter("@PlayTime", MySqlDbType.DateTime, -1) { Value = model.PlayTime },
				model.Discount == null ? new MySqlParameter("@Discount", MySqlDbType.VarChar, 255) { Value = DBNull.Value } : new MySqlParameter("@Discount", MySqlDbType.VarChar, 255) { Value = model.Discount }
			};
			int maxID;
			return int.TryParse(dbHelper.ExecuteScalar(sql, parameters),out maxID) ? maxID : -1;
		}
		/// <summary>
		/// 更新记录
		/// </summary>
		/// <param name="model">Model.Schedule实体类</param>
		public int Update(Model.Schedule model)
		{
			string sql = @"UPDATE Schedule SET 
				MovieID=@MovieID,HallID=@HallID,PlayTime=@PlayTime,Discount=@Discount
				WHERE ID=@ID";
			MySqlParameter[] parameters = new MySqlParameter[]{
				model.MovieID == null ? new MySqlParameter("@MovieID", MySqlDbType.Int32, 11) { Value = DBNull.Value } : new MySqlParameter("@MovieID", MySqlDbType.Int32, 11) { Value = model.MovieID },
				model.HallID == null ? new MySqlParameter("@HallID", MySqlDbType.Int32, 255) { Value = DBNull.Value } : new MySqlParameter("@HallID", MySqlDbType.Int32, 255) { Value = model.HallID },
				model.PlayTime == null ? new MySqlParameter("@PlayTime", MySqlDbType.DateTime, -1) { Value = DBNull.Value } : new MySqlParameter("@PlayTime", MySqlDbType.DateTime, -1) { Value = model.PlayTime },
				model.Discount == null ? new MySqlParameter("@Discount", MySqlDbType.VarChar, 255) { Value = DBNull.Value } : new MySqlParameter("@Discount", MySqlDbType.VarChar, 255) { Value = model.Discount },
				new MySqlParameter("@ID", MySqlDbType.Int32, 11){ Value = model.ID }
			};
			return dbHelper.Execute(sql, parameters);
		}
		/// <summary>
		/// 删除记录
		/// </summary>
		public int Delete(int id)
		{
			string sql = "DELETE FROM Schedule WHERE ID=@ID";
			MySqlParameter[] parameters = new MySqlParameter[]{
				new MySqlParameter("@ID", MySqlDbType.Int32, 11){ Value = id }
			};
			return dbHelper.Execute(sql, parameters);
		}
		/// <summary>
		/// 将DataRedar转换为List
		/// </summary>
		private List<Model.Schedule> DataReaderToList(MySqlDataReader dataReader)
		{
			List<Model.Schedule> List = new List<Model.Schedule>();
			Model.Schedule model = null;
			while(dataReader.Read())
			{
				model = new Model.Schedule();
				model.ID = dataReader.GetInt32(0);
				if (!dataReader.IsDBNull(1))
					model.MovieID = dataReader.GetInt32(1);
				if (!dataReader.IsDBNull(2))
					model.HallID = dataReader.GetInt32(2);
				if (!dataReader.IsDBNull(3))
					model.PlayTime = dataReader.GetDateTime(3);
				if (!dataReader.IsDBNull(4))
					model.Discount = dataReader.GetString(4);
				List.Add(model);
			}
			return List;
		}
		/// <summary>
		/// 查询所有记录
		/// </summary>
		public List<Model.Schedule> GetAll()
		{
			string sql = "SELECT * FROM Schedule";
			MySqlDataReader dataReader = dbHelper.GetDataReader(sql);
			List<Model.Schedule> List = DataReaderToList(dataReader);
			dataReader.Close();
			return List;
		}
		/// <summary>
		/// 查询所有上映电影记录
		/// </summary>
		public List<Model.Schedule> GetAllSchedule()
		{
			string sql = "SELECT ID, MovieID, HallID, PlayTime, Discount FROM `Schedule` WHERE MovieID IN (SELECT MovieID FROM Movie) ORDER BY MovieID, PlayTime";
			MySqlDataReader dataReader = dbHelper.GetDataReader(sql);
			List<Model.Schedule> List = DataReaderToList(dataReader);
			dataReader.Close();
			return List;
		}
		/// <summary>
		/// 查询记录数
		/// </summary>
		public long GetCount()
		{
			string sql = "SELECT COUNT(*) FROM Schedule";
			long count;
			return long.TryParse(dbHelper.GetFieldValue(sql), out count) ? count : 0;
		}
		/// <summary>
		/// 根据主键查询一条记录
		/// </summary>
		public Model.Schedule Get(int id)
		{
			string sql = "SELECT * FROM Schedule WHERE ID=@ID";
			MySqlParameter[] parameters = new MySqlParameter[]{
				new MySqlParameter("@ID", MySqlDbType.Int32, 11){ Value = id }
			};
			MySqlDataReader dataReader = dbHelper.GetDataReader(sql, parameters);
			List<Model.Schedule> List = DataReaderToList(dataReader);
			dataReader.Close();
			return List.Count > 0 ? List[0] : null;
		}
	}
}