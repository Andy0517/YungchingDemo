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
        [HttpPost]
        public IActionResult POST([FromBody] QueryModel viewModel)
        {
            //var sqlService = new SqlService();

            string sql = "SELECT * FROM [dbo].[Result] WHERE 1=1";

            try
            {
                //執行SQL查詢，取得結果
                //var result = sqlService.ReadOne<ResultModel>(sql);
                //將結果轉換為JSON格式

                var test = new ResultModel()
                {
                    ProjectID = viewModel.ProjectID,
                    ProjectName = "測試專案",
                    Type = "01",
                    Address = "台北市信義區",
                    Price = 1000,
                    Square = 30.5m,
                    PublicRatio = 20,
                    HaveSpace = "1",
                    Remark = "測試備註"
                };
                return new JsonResult(new { message = $"{viewModel.ProjectID}查詢成功！", data = test });
            }
            catch (Exception ex)
            {
                return new JsonResult(new { message = $"{viewModel.ProjectID}查詢失敗！({ex.Message})" });
            }
        }
    }
}
