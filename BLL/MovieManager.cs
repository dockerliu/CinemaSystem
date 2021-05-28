using System;
using System.Collections.Generic;
using System.Text;

namespace BLL
{
	public class MovieManager
	{
		private DAL.MovieService dataMovie;
		public MovieManager()
		{
			this.dataMovie = new DAL.MovieService();
		}
		/// <summary>
		/// 新增
		/// </summary>
		public int Add(Model.Movie model)
		{
			return dataMovie.Add(model);
		}
		/// <summary>
		/// 更新
		/// </summary>
		public int Update(Model.Movie model)
		{
			return dataMovie.Update(model);
		}
		/// <summary>
		/// 查询所有记录
		/// </summary>
		public List<Model.Movie> GetAll()
		{
			return dataMovie.GetAll();
		}
		/// <summary>
		/// 查询单条记录
		/// </summary>
		public Model.Movie Get(int movieid)
		{
			return dataMovie.Get(movieid);
		}
		/// <summary>
		/// 删除
		/// </summary>
		public int Delete(int movieid)
		{
			return dataMovie.Delete(movieid);
		}
		/// <summary>
		/// 查询记录条数
		/// </summary>
		public long GetCount()
		{
			return dataMovie.GetCount();
		}
	}
}
