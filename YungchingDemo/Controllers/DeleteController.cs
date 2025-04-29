using Dapper;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using System.Data;
using YungchingDemo.Comm;
using YungchingDemo.Models;

namespace YungchingDemo.Controllers
{
    [ApiController]
    [Route("api/DeleteInformation")]
    public class DeleteController : ControllerBase
    {
        private readonly SqlService _sqlService;
        // 使用依賴注入將 SqlService 傳入
        public DeleteController(SqlService sqlService)
        {
            _sqlService = sqlService;
        }
        [HttpPost]
        public IActionResult POST([FromBody] QueryModel viewModel)
        {
            string sql = @"DELETE FROM T_ESTATE_Data WHERE ProjectID = @ProjectID";

            try
            {
                var Params = new DynamicParameters();
                Params.Add("@ProjectID", viewModel.ProjectID, DbType.AnsiString);
                //執行SQL查詢，取得結果
                var result = _sqlService.Execute(sql, Params);
                //將結果轉換為JSON格式
                return new JsonResult(new { message = $"{viewModel.ProjectID}刪除成功！" });
            }
            catch (Exception ex)
            {
                return new JsonResult(new { message = $"{viewModel.ProjectID}刪除失敗！({ex.Message})" });
            }
        }
    }
}
