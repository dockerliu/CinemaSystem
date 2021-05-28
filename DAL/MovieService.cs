using System;
using System.Collections.Generic;
using System.Text;
using System.Data;
using MySql.Data.MySqlClient;

namespace DAL
{
	public class MovieService
	{
		private DbHelper dbHelper = new DbHelper();
		/// <summary>
		/// 构造函数
		/// </summary>
		public MovieService()
		{
		}
		/// <summary>
		/// 添加记录
		/// </summary>
		/// <param name="model">Model.Movie实体类</param>
		/// <returns>新增记录的ID</returns>
		public int Add(Model.Movie model)
		{
			string sql = @"INSERT INTO Movie
				(MovieName,Poster,Director,Actor,MovieType,Duration,Price,IsTop) 
				VALUES(@MovieName,@Poster,@Director,@Actor,@MovieType,@Duration,@Price,@IsTop);
				SELECT LAST_INSERT_ID();";
			MySqlParameter[] parameters = new MySqlParameter[]{
				model.MovieName == null ? new MySqlParameter("@MovieName", MySqlDbType.VarChar, 50) { Value = DBNull.Value } : new MySqlParameter("@MovieName", MySqlDbType.VarChar, 50) { Value = model.MovieName },
				model.Poster == null ? new MySqlParameter("@Poster", MySqlDbType.VarChar, 200) { Value = DBNull.Value } : new MySqlParameter("@Poster", MySqlDbType.VarChar, 200) { Value = model.Poster },
				model.Director == null ? new MySqlParameter("@Director", MySqlDbType.VarChar, 100) { Value = DBNull.Value } : new MySqlParameter("@Director", MySqlDbType.VarChar, 100) { Value = model.Director },
				model.Actor == null ? new MySqlParameter("@Actor", MySqlDbType.VarChar, 100) { Value = DBNull.Value } : new MySqlParameter("@Actor", MySqlDbType.VarChar, 100) { Value = model.Actor },
				model.MovieType == null ? new MySqlParameter("@MovieType", MySqlDbType.VarChar, 50) { Value = DBNull.Value } : new MySqlParameter("@MovieType", MySqlDbType.VarChar, 50) { Value = model.MovieType },
				model.Duration == null ? new MySqlParameter("@Duration", MySqlDbType.VarChar, 20) { Value = DBNull.Value } : new MySqlParameter("@Duration", MySqlDbType.VarChar, 20) { Value = model.Duration },
				model.Price == null ? new MySqlParameter("@Price", MySqlDbType.VarChar, 255) { Value = DBNull.Value } : new MySqlParameter("@Price", MySqlDbType.VarChar, 255) { Value = model.Price },
				model.IsTop == null ? new MySqlParameter("@IsTop", MySqlDbType.Bit, 1) { Value = DBNull.Value } : new MySqlParameter("@IsTop", MySqlDbType.Bit, 1) { Value = model.IsTop }
			};
			int maxID;
			return int.TryParse(dbHelper.ExecuteScalar(sql, parameters),out maxID) ? maxID : -1;
		}
		/// <summary>
		/// 更新记录
		/// </summary>
		/// <param name="model">Model.Movie实体类</param>
		public int Update(Model.Movie model)
		{
			string sql = @"UPDATE Movie SET 
				MovieName=@MovieName,Poster=@Poster,Director=@Director,Actor=@Actor,MovieType=@MovieType,Duration=@Duration,Price=@Price,IsTop=@IsTop
				WHERE MovieId=@MovieId";
			MySqlParameter[] parameters = new MySqlParameter[]{
				model.MovieName == null ? new MySqlParameter("@MovieName", MySqlDbType.VarChar, 50) { Value = DBNull.Value } : new MySqlParameter("@MovieName", MySqlDbType.VarChar, 50) { Value = model.MovieName },
				model.Poster == null ? new MySqlParameter("@Poster", MySqlDbType.VarChar, 200) { Value = DBNull.Value } : new MySqlParameter("@Poster", MySqlDbType.VarChar, 200) { Value = model.Poster },
				model.Director == null ? new MySqlParameter("@Director", MySqlDbType.VarChar, 100) { Value = DBNull.Value } : new MySqlParameter("@Director", MySqlDbType.VarChar, 100) { Value = model.Director },
				model.Actor == null ? new MySqlParameter("@Actor", MySqlDbType.VarChar, 100) { Value = DBNull.Value } : new MySqlParameter("@Actor", MySqlDbType.VarChar, 100) { Value = model.Actor },
				model.MovieType == null ? new MySqlParameter("@MovieType", MySqlDbType.VarChar, 50) { Value = DBNull.Value } : new MySqlParameter("@MovieType", MySqlDbType.VarChar, 50) { Value = model.MovieType },
				model.Duration == null ? new MySqlParameter("@Duration", MySqlDbType.VarChar, 20) { Value = DBNull.Value } : new MySqlParameter("@Duration", MySqlDbType.VarChar, 20) { Value = model.Duration },
				model.Price == null ? new MySqlParameter("@Price", MySqlDbType.VarChar, 255) { Value = DBNull.Value } : new MySqlParameter("@Price", MySqlDbType.VarChar, 255) { Value = model.Price },
				model.IsTop == null ? new MySqlParameter("@IsTop", MySqlDbType.Bit, 1) { Value = DBNull.Value } : new MySqlParameter("@IsTop", MySqlDbType.Bit, 1) { Value = model.IsTop },
				new MySqlParameter("@MovieId", MySqlDbType.Int32, 11){ Value = model.MovieId }
			};
			return dbHelper.Execute(sql, parameters);
		}
		/// <summary>
		/// 删除记录
		/// </summary>
		public int Delete(int movieid)
		{
			string sql = "DELETE FROM Movie WHERE MovieId=@MovieId";
			MySqlParameter[] parameters = new MySqlParameter[]{
				new MySqlParameter("@MovieId", MySqlDbType.Int32, 11){ Value = movieid }
			};
			return dbHelper.Execute(sql, parameters);
		}
		/// <summary>
		/// 将DataRedar转换为List
		/// </summary>
		private List<Model.Movie> DataReaderToList(MySqlDataReader dataReader)
		{
			List<Model.Movie> List = new List<Model.Movie>();
			Model.Movie model = null;
			while(dataReader.Read())
			{
				model = new Model.Movie();
				model.MovieId = dataReader.GetInt32(0);
				if (!dataReader.IsDBNull(1))
					model.MovieName = dataReader.GetString(1);
				if (!dataReader.IsDBNull(2))
					model.Poster = dataReader.GetString(2);
				if (!dataReader.IsDBNull(3))
					model.Director = dataReader.GetString(3);
				if (!dataReader.IsDBNull(4))
					model.Actor = dataReader.GetString(4);
				if (!dataReader.IsDBNull(5))
					model.MovieType = dataReader.GetString(5);
				if (!dataReader.IsDBNull(6))
					model.Duration = dataReader.GetString(6);
				if (!dataReader.IsDBNull(7))
					model.Price = dataReader.GetString(7);
				if (!dataReader.IsDBNull(8))
					model.IsTop = dataReader.GetBoolean(8);
				List.Add(model);
			}
			return List;
		}
		/// <summary>
		/// 查询所有记录
		/// </summary>
		public List<Model.Movie> GetAll()
		{
			string sql = "SELECT * FROM Movie";
			MySqlDataReader dataReader = dbHelper.GetDataReader(sql);
			List<Model.Movie> List = DataReaderToList(dataReader);
			dataReader.Close();
			return List;
		}
		/// <summary>
		/// 查询记录数
		/// </summary>
		public long GetCount()
		{
			string sql = "SELECT COUNT(*) FROM Movie";
			long count;
			return long.TryParse(dbHelper.GetFieldValue(sql), out count) ? count : 0;
		}
		/// <summary>
		/// 根据主键查询一条记录
		/// </summary>
		public Model.Movie Get(int movieid)
		{
			string sql = "SELECT * FROM Movie WHERE MovieId=@MovieId";
			MySqlParameter[] parameters = new MySqlParameter[]{
				new MySqlParameter("@MovieId", MySqlDbType.Int32, 11){ Value = movieid }
			};
			MySqlDataReader dataReader = dbHelper.GetDataReader(sql, parameters);
			List<Model.Movie> List = DataReaderToList(dataReader);
			dataReader.Close();
			return List.Count > 0 ? List[0] : null;
		}
	}
}