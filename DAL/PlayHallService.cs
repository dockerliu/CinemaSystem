using System;
using System.Collections.Generic;
using System.Text;
using System.Data;
using MySql.Data.MySqlClient;

namespace DAL
{
	public class PlayHallService
	{
		private DbHelper dbHelper = new DbHelper();
		/// <summary>
		/// 构造函数
		/// </summary>
		public PlayHallService()
		{
		}
		/// <summary>
		/// 添加记录
		/// </summary>
		/// <param name="model">Model.PlayHall实体类</param>
		/// <returns>操作所影响的行数</returns>
		public int Add(Model.PlayHall model)
		{
			string sql = @"INSERT INTO PlayHall
				(HallId,HallName,SeatList,IsValid) 
				VALUES(@HallId,@HallName,@SeatList,@IsValid)";
			MySqlParameter[] parameters = new MySqlParameter[]{
				new MySqlParameter("@HallId", MySqlDbType.Int32, 11){ Value = model.HallId },
				model.HallName == null ? new MySqlParameter("@HallName", MySqlDbType.VarChar, 50) { Value = DBNull.Value } : new MySqlParameter("@HallName", MySqlDbType.VarChar, 50) { Value = model.HallName },
				model.SeatList == null ? new MySqlParameter("@SeatList", MySqlDbType.VarChar, 255) { Value = DBNull.Value } : new MySqlParameter("@SeatList", MySqlDbType.VarChar, 255) { Value = model.SeatList },
				model.IsValid == null ? new MySqlParameter("@IsValid", MySqlDbType.Bit, 1) { Value = DBNull.Value } : new MySqlParameter("@IsValid", MySqlDbType.Bit, 1) { Value = model.IsValid }
			};
			return dbHelper.Execute(sql, parameters);
		}
		/// <summary>
		/// 更新记录
		/// </summary>
		/// <param name="model">Model.PlayHall实体类</param>
		public int Update(Model.PlayHall model)
		{
			string sql = @"UPDATE PlayHall SET 
				HallName=@HallName,SeatList=@SeatList,IsValid=@IsValid
				WHERE HallId=@HallId";
			MySqlParameter[] parameters = new MySqlParameter[]{
				model.HallName == null ? new MySqlParameter("@HallName", MySqlDbType.VarChar, 50) { Value = DBNull.Value } : new MySqlParameter("@HallName", MySqlDbType.VarChar, 50) { Value = model.HallName },
				model.SeatList == null ? new MySqlParameter("@SeatList", MySqlDbType.VarChar, 255) { Value = DBNull.Value } : new MySqlParameter("@SeatList", MySqlDbType.VarChar, 255) { Value = model.SeatList },
				model.IsValid == null ? new MySqlParameter("@IsValid", MySqlDbType.Bit, 1) { Value = DBNull.Value } : new MySqlParameter("@IsValid", MySqlDbType.Bit, 1) { Value = model.IsValid },
				new MySqlParameter("@HallId", MySqlDbType.Int32, 11){ Value = model.HallId }
			};
			return dbHelper.Execute(sql, parameters);
		}
		/// <summary>
		/// 删除记录
		/// </summary>
		public int Delete(int hallid)
		{
			string sql = "DELETE FROM PlayHall WHERE HallId=@HallId";
			MySqlParameter[] parameters = new MySqlParameter[]{
				new MySqlParameter("@HallId", MySqlDbType.Int32, 11){ Value = hallid }
			};
			return dbHelper.Execute(sql, parameters);
		}
		/// <summary>
		/// 将DataRedar转换为List
		/// </summary>
		private List<Model.PlayHall> DataReaderToList(MySqlDataReader dataReader)
		{
			List<Model.PlayHall> List = new List<Model.PlayHall>();
			Model.PlayHall model = null;
			while(dataReader.Read())
			{
				model = new Model.PlayHall();
				model.HallId = dataReader.GetInt32(0);
				if (!dataReader.IsDBNull(1))
					model.HallName = dataReader.GetString(1);
				if (!dataReader.IsDBNull(2))
					model.SeatList = dataReader.GetString(2);
				if (!dataReader.IsDBNull(3))
					model.IsValid = dataReader.GetBoolean(3);
				List.Add(model);
			}
			return List;
		}
		/// <summary>
		/// 查询所有记录
		/// </summary>
		public List<Model.PlayHall> GetAll()
		{
			string sql = "SELECT * FROM PlayHall";
			MySqlDataReader dataReader = dbHelper.GetDataReader(sql);
			List<Model.PlayHall> List = DataReaderToList(dataReader);
			dataReader.Close();
			return List;
		}
		/// <summary>
		/// 查询记录数
		/// </summary>
		public long GetCount()
		{
			string sql = "SELECT COUNT(*) FROM PlayHall";
			long count;
			return long.TryParse(dbHelper.GetFieldValue(sql), out count) ? count : 0;
		}
		/// <summary>
		/// 根据主键查询一条记录
		/// </summary>
		public Model.PlayHall Get(int hallid)
		{
			string sql = "SELECT * FROM PlayHall WHERE HallId=@HallId";
			MySqlParameter[] parameters = new MySqlParameter[]{
				new MySqlParameter("@HallId", MySqlDbType.Int32, 11){ Value = hallid }
			};
			MySqlDataReader dataReader = dbHelper.GetDataReader(sql, parameters);
			List<Model.PlayHall> List = DataReaderToList(dataReader);
			dataReader.Close();
			return List.Count > 0 ? List[0] : null;
		}
	}
}