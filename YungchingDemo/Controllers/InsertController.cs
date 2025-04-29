using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using YungchingDemo.Comm;
using YungchingDemo.Models;

namespace YungchingDemo.Controllers
{
    [ApiController]
    [Route("api/InsertInformation")]
    public class InsertController : ControllerBase
    {
        [HttpPost]
        public IActionResult POST([FromBody] ResultModel viewModel)
        {
            // var sqlService = new SqlService();

            string sql = $"SELECT * FROM [dbo].[Result] WHERE 1=1";

            try
            {
                //執行SQL查詢，取得結果
                // var result = sqlService.Execute(sql);
                //將結果轉換為JSON格式
                return new JsonResult(new { message = $"{viewModel.ProjectID}新增成功！" });
            }
            catch (Exception ex)
            {
                return new JsonResult(new { message = $"{viewModel.ProjectID}新增失敗！({ex.Message})" });
            }
        }
    }
}
