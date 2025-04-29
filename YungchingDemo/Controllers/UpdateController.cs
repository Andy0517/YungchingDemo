using Dapper;
using Microsoft.AspNetCore.Mvc;
using System.Data;
using YungchingDemo.Comm;
using YungchingDemo.Models;

namespace YungchingDemo.Controllers
{
    [ApiController]
    [Route("api/UpdateInformation")]
    public class UpdateController : ControllerBase
    {
        private readonly SqlService _sqlService;
        // 使用依賴注入將 SqlService 傳入
        public UpdateController(SqlService sqlService)
        {
            _sqlService = sqlService;
        }
        [HttpPost]
        public IActionResult POST([FromBody] ResultModel viewModel)
        {
            string sql = @"UPDATE T_ESTATE_Data SET ProjectID = ProjectID, 
                                                    ProjectName = @ProjectName,
                                                    Type = @Type,
                                                    Address = @Address,
                                                    Square = @Square,
                                                    PublicRatio = @PublicRatio,
                                                    Price = @Price,
                                                    HaveSpace = @HaveSpace,
                                                    Remark = @Remark
                                                    WHERE ProjectID = @ProjectID";

            try
            {
                var Params = new DynamicParameters();
                //將參數加入到DynamicParameters中
                Params.Add("@ProjectID", viewModel.ProjectID, DbType.AnsiString);
                Params.Add("@ProjectName", viewModel.ProjectName, DbType.String);
                Params.Add("@Type", viewModel.Type, DbType.AnsiString);
                Params.Add("@Address", viewModel.Address, DbType.String);
                Params.Add("@Square", viewModel.Square, DbType.Decimal);
                Params.Add("@PublicRatio", viewModel.PublicRatio, DbType.Int32);
                Params.Add("@Price", viewModel.Price, DbType.Int32);
                Params.Add("@HaveSpace", viewModel.HaveSpace, DbType.AnsiString);
                Params.Add("@Remark", viewModel.Remark, DbType.String);
                //執行SQL查詢，取得結果
                var result = _sqlService.Execute(sql, Params);
                //將結果轉換為JSON格式
                return new JsonResult(new { message = $"{viewModel.ProjectID}更新成功！" });
            }
            catch (Exception ex)
            {
                return new JsonResult(new { message = $"{viewModel.ProjectID}更新失敗！({ex.Message})" });
            }
        }
    }
}
