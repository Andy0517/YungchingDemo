using Dapper;
using Microsoft.Data.SqlClient;

namespace YungchingDemo.Comm
{
    public class SqlService
    {
        //從appsettings.json中讀取連線字串
        private readonly string _connectString = System.Configuration.ConfigurationManager.ConnectionStrings["DefaultConnection"].ConnectionString;

        public T ReadOne<T>(string sql, object param = null)
        {
            using (var connection = new SqlConnection(_connectString))
            {
                connection.Open();
                var result = connection.Query<T>(sql, param).ToList()[0]; // 只取第一筆資料
                connection.Close();
                return result;
            }
        }
        public List<T> ReadMany<T>(string sql, object param = null)
        {
            using (var connection = new SqlConnection(_connectString))
            {
                connection.Open();
                var result = connection.Query<T>(sql, param).ToList();
                connection.Close();
                return result;
            }
        }

        public int Execute(string sql, object param = null)
        {
            int result = 0;

            using (var connection = new SqlConnection(_connectString))
            {
                connection.Open();
                using (var transaction = connection.BeginTransaction())
                {
                    try
                    {
                        result= connection.Execute(sql, param, transaction);
                        transaction.Commit();
                    }
                    catch (Exception ex)
                    {
                        transaction.Rollback();
                        throw ex;
                    }
                }
                connection.Close();
            }
        
            return result;
        }
    }
}