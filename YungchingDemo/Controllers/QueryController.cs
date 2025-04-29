using System.Data;
using Dapper;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using YungchingDemo.Comm;
using YungchingDemo.Models;

namespace YungchingDemo.Controllers
{
    [ApiController]
    [Route("api/QueryInformation")]
    public class QueryController : ControllerBase
    {
        private readonly SqlService _sqlService;

        // 使用依賴注入將 SqlService 傳入
        public QueryController(SqlService sqlService)
        {
            _sqlService = sqlService;
        }
        [HttpPost]
        public IActionResult POST([FromBody] QueryModel viewModel)
        {
            string sql = @"SELECT * FROM T_ESTATE_Data WHERE ProjectID = @ProjectID";

            try
            {
                var Params = new DynamicParameters();
                Params.Add("@ProjectID", viewModel.ProjectID, DbType.AnsiString);
                //執行SQL查詢，取得結果
                var result = _sqlService.ReadOne<ResultModel>(sql,Params);

                return new JsonResult(new { message = $"{viewModel.ProjectID}查詢成功！", data = result });
            }
            catch (Exception ex)
            {
                return new JsonResult(new { message = $"{viewModel.ProjectID}查詢失敗！({ex.Message})" });
            }
        }
    }
}
