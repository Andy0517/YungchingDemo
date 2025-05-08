using Dapper;
using System.Data;
using YungchingDemo.Models;

namespace YungchingDemo.Comm
{
    public class ComboBoxService
    {
        private readonly SqlService _SqlService;
        public ComboBoxService(string connectString)
        {
            _SqlService = new SqlService(connectString);
        }
        public List<ComboBoxModel> Get(string groupName)
        {

            string sql = @"SELECT OptionCode AS CODEID, OptionName AS CODENAME
                                  FROM T_DropdownOptions
                           WHERE GroupName = @GroupName ORDER BY OptionCode ";
            DynamicParameters Params = new DynamicParameters();
            Params.Add("@GroupName", groupName, DbType.AnsiString);

            var result = _SqlService.ReadMany<ComboBoxModel>(sql, Params);

            return result;
        }
    }
}
