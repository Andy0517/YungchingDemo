using Microsoft.AspNetCore.Mvc.RazorPages;
using YungchingDemo.Models;

namespace YungchingDemo.Pages
{
    public class InsertModel : PageModel
    {
        public ResultModel _Result = new ResultModel();
        private readonly ILogger<InsertModel> _logger;

        public InsertModel(ILogger<InsertModel> logger)
        {
            _logger = logger;
        }

        public void OnGet()
        {
        }
    }

}
