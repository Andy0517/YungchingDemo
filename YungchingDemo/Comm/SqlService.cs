using Dapper;
using Microsoft.Data.SqlClient;

namespace YungchingDemo.Comm
{
    public class SqlService
    {
        private readonly string _connectString="";

        // 使用依賴注入從 appsettings.json 中取得連線字串
        public SqlService(IConfiguration configuration)
        {
            _connectString = configuration.GetConnectionString("DefaultConnection");
        }
        public T ReadOne<T>(string sql, object param = null)
        {
            try
            {
                return ReadMany<T>(sql, param)[0];
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        public List<T> ReadMany<T>(string sql, object param = null)
        {
            try
            {
                using (var connection = new SqlConnection(_connectString))
                {
                    connection.Open();
                    var result = connection.Query<T>(sql, param).ToList();
                    connection.Close();

                    if (result.Count == 0)
                    {
                        throw new Exception("資料不存在");
                    }

                    return result;
                }
            }
            catch (Exception ex)
            {
                throw ex;
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
                        result = connection.Execute(sql, param, transaction);
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