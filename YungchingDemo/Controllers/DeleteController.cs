using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using YungchingDemo.Comm;
using YungchingDemo.Models;

namespace YungchingDemo.Controllers
{
    [ApiController]
    [Route("api/DeleteInformation")]
    public class DeleteController : ControllerBase
    {
        [HttpPost]
        public IActionResult POST([FromBody] QueryModel viewModel)
        {
            // var sqlService = new SqlService();

            string sql = $"SELECT * FROM [dbo].[Result] WHERE 1=1";

            try
            {
                //執行SQL查詢，取得結果
                //var result = sqlService.Execute(sql);
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
