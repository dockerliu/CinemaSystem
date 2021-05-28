using System;
using System.Text;
using System.Data;
using MySql.Data.MySqlClient;

namespace DAL
{
    /// <summary>
    /// MySql助手类
    /// </summary>
    public class DbHelper
    {
        public DbHelper()
        {
            this.connectionString = "server=192.168.1.95;database=cinemasystem;uid=cinema;pwd=111111;charset='utf8';SslMode = none;";
        }
        public DbHelper(string connString)
        {
            this.connectionString = connString;
        }
        private string connectionString;
        private MySqlConnection connection;
        /// <summary>
        /// 连接字符串
        /// </summary>
        public string ConnectionString
        {
            get { return this.connectionString; }
        }
        /// <summary>
        /// 数据连接
        /// </summary>
        public MySqlConnection Connection
        {
            get 
            {
                if (this.connection == null)
                {
                    this.connection = new MySqlConnection(this.connectionString);
                    this.connection.Open();
                }
                else if (this.connection.State != ConnectionState.Open)
                {
                    this.connection.Open();
                }
                return this.connection;
            }
        }
        
        /// <summary>
        /// 释放连接
        /// </summary>
        public void Dispose()
        {
            if (this.connection != null && this.connection.State != ConnectionState.Closed)
            {
                this.connection.Close();
            }
            this.connection.Dispose();
        }

        /// <summary>
        /// 得到一个MySqlDataReader
        /// </summary>
        /// <param name="MySql">MySql语句</param>
        /// <returns></returns>
        public MySqlDataReader GetDataReader(string sql)
        {
            this.connection = new MySqlConnection(ConnectionString);
            this.connection.Open();
            using (MySqlCommand cmd = new MySqlCommand(sql, this.connection))
            {
                cmd.Prepare();
                return cmd.ExecuteReader(CommandBehavior.CloseConnection);
            }
        }

        /// <summary>
        /// 得到一个MySqlDataReader
        /// </summary>
        /// <param name="MySql">MySql语句</param>
        /// <returns></returns>
        public MySqlDataReader GetDataReader(string sql, MySqlParameter[] parameter)
        {
            this.connection = new MySqlConnection(ConnectionString);
            this.connection.Open();
            using (MySqlCommand cmd = new MySqlCommand(sql, this.connection))
            {
                if (parameter != null && parameter.Length > 0)
                    cmd.Parameters.AddRange(parameter);
                MySqlDataReader dr = cmd.ExecuteReader(CommandBehavior.CloseConnection);
                cmd.Parameters.Clear();
                cmd.Prepare();
                return dr;
            }
        }

        /// <summary>
        /// 得到一个DataTable
        /// </summary>
        /// <param name="MySql">MySql语句</param>
        /// <returns></returns>
        public DataTable GetDataTable(string sql)
        {
            using (this.connection = new MySqlConnection(ConnectionString))
            {
                this.connection.Open();
                using (MySqlCommand cmd = new MySqlCommand(sql, this.connection))
                {
                    MySqlDataReader dr = cmd.ExecuteReader();
                    DataTable dt = new DataTable();
                    dt.Load(dr);
                    dr.Close();
                    dr.Dispose();
                    cmd.Prepare();
                    return dt;
                }
            }
        }

        /// <summary>
        /// 得到一个DataTable
        /// </summary>
        /// <param name="MySql">MySql语句</param>
        /// <returns></returns>
        public DataTable GetDataTable(string sql, MySqlParameter[] parameter)
        {
            using (this.connection = new MySqlConnection(ConnectionString))
            {
                this.connection.Open();
                using (MySqlCommand cmd = new MySqlCommand(sql, this.connection))
                {
                    if (parameter != null && parameter.Length > 0)
                        cmd.Parameters.AddRange(parameter);
                    MySqlDataReader dr = cmd.ExecuteReader();
                    DataTable dt = new DataTable();
                    dt.Load(dr);
                    dr.Close();
                    dr.Dispose();
                    cmd.Parameters.Clear();
                    cmd.Prepare();
                    return dt;
                }
            }
        }

        /// <summary>
        /// 得到数据集
        /// </summary>
        /// <param name="MySql"></param>
        /// <returns></returns>
        public DataSet GetDataSet(string sql)
        {
            using (this.connection = new MySqlConnection(ConnectionString))
            {
                this.connection.Open();
                using (MySqlDataAdapter dap = new MySqlDataAdapter(sql, this.connection))
                {
                    DataSet ds = new DataSet();
                    dap.Fill(ds);
                    return ds;
                }
            }
        }

        /// <summary>
        /// 执行MySql
        /// </summary>
        /// <param name="MySql"></param>
        /// <returns></returns>
        public int Execute(string sql)
        {
            using (this.connection = new MySqlConnection(ConnectionString))
            {
                this.connection.Open();
                using (MySqlCommand cmd = new MySqlCommand(sql, this.connection))
                {
                    cmd.Prepare();
                    return cmd.ExecuteNonQuery();
                }
            }
        }

        /// <summary>
        /// 执行带参数的Sql
        /// </summary>
        /// <param name="MySql"></param>
        /// <param name="param"></param>
        /// <returns></returns>
        public int Execute(string sql, MySqlParameter[] parameter)
        {
            using (this.connection = new MySqlConnection(ConnectionString))
            {
                this.connection.Open();
                using (MySqlCommand cmd = new MySqlCommand(sql, this.connection))
                {
                    if (parameter != null && parameter.Length > 0)
                        cmd.Parameters.AddRange(parameter);
                    int i = cmd.ExecuteNonQuery();
                    cmd.Parameters.Clear();
                    cmd.Prepare();
                    return i;
                }
            }
        }

        /// <summary>
        /// 或者一行一列
        /// </summary>
        /// <param name="sql">SQL查询语句</param>
        /// <returns></returns>
        internal string GetFieldValue(string sql)
        {
            using (this.connection = new MySqlConnection(ConnectionString))
            {
                this.connection.Open();
                using (MySqlCommand cmd = new MySqlCommand(sql, this.connection))
                {
                    cmd.Prepare();
                    return cmd.ExecuteNonQuery().ToString();
                }
            }
        }

        /// <summary>
        /// 得到一个字段的值
        /// </summary>
        /// <param name="MySql"></param>
        /// <returns></returns>
        public string ExecuteScalar(string sql)
        {
            using (this.connection = new MySqlConnection(ConnectionString))
            {
                this.connection.Open();
                using (MySqlCommand cmd = new MySqlCommand(sql, this.connection))
                {
                    object obj = cmd.ExecuteScalar();
                    cmd.Prepare();
                    return obj != null ? obj.ToString() : string.Empty;
                }
            }
        }

        /// <summary>
        /// 得到一个字段的值
        /// </summary>
        /// <param name="MySql"></param>
        /// <returns></returns>
        public string ExecuteScalar(string sql, MySqlParameter[] parameter)
        {
            using (this.connection = new MySqlConnection(ConnectionString))
            {
                this.connection.Open();
                using (MySqlCommand cmd = new MySqlCommand(sql, this.connection))
                {
                    if (parameter != null && parameter.Length > 0)
                        cmd.Parameters.AddRange(parameter);
                    object obj = cmd.ExecuteScalar();
                    cmd.Parameters.Clear();
                    cmd.Prepare();
                    return obj != null ? obj.ToString() : string.Empty;
                }
            }
        }

        /// <summary>
        /// 获取一个Sql的字段名称
        /// </summary>
        /// <param name="MySql">MySql语句</param>
        /// <returns></returns>
        public string GetFields(string sql, MySqlParameter[] param)
        {
            using (this.connection = new MySqlConnection(ConnectionString))
            {
                this.connection.Open();
                System.Text.StringBuilder names = new System.Text.StringBuilder(500);
                using (MySqlCommand cmd = new MySqlCommand(sql, this.connection))
                {
                    if (param != null && param.Length > 0)
                        cmd.Parameters.AddRange(param);
                    MySqlDataReader dr = cmd.ExecuteReader(CommandBehavior.SchemaOnly);
                    for (int i = 0; i < dr.FieldCount; i++)
                    {
                        names.Append("[" + dr.GetName(i) + "]" + (i < dr.FieldCount - 1 ? "," : string.Empty));
                    }
                    cmd.Parameters.Clear();
                    dr.Close();
                    dr.Dispose();
                    cmd.Prepare();
                    return names.ToString();
                }
            }
        }

        /// <summary>
        /// 获取一个Sql的字段名称
        /// </summary>
        /// <param name="MySql"></param>
        /// <param name="param"></param>
        /// <param name="tableName">表名 </param>
        /// <returns></returns>
        public string GetFields(string sql, MySqlParameter[] param, out string tableName)
        {
            using (this.connection = new MySqlConnection(ConnectionString))
            {
                this.connection.Open();
                System.Text.StringBuilder names = new System.Text.StringBuilder(500);
                using (MySqlCommand cmd = new MySqlCommand(sql, this.connection))
                {
                    if (param != null && param.Length > 0)
                        cmd.Parameters.AddRange(param);
                    MySqlDataReader dr = cmd.ExecuteReader(CommandBehavior.SchemaOnly);
                    tableName = dr.GetSchemaTable().TableName;
                    for (int i = 0; i < dr.FieldCount; i++)
                    {
                        names.Append("[" + dr.GetName(i) + "]" + (i < dr.FieldCount - 1 ? "," : string.Empty));
                    }
                    cmd.Parameters.Clear();
                    dr.Close();
                    dr.Dispose();
                    cmd.Prepare();
                    return names.ToString();
                }
            }
        }
       
    }
}
