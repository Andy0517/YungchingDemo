using Microsoft.AspNetCore.Mvc.RazorPages;
using YungchingDemo.Models;

namespace YungchingDemo.Pages
{
    public class MaintainModel : PageModel
    {
        private readonly ILogger<MaintainModel> _logger;

        public MaintainModel(ILogger<MaintainModel> logger)
        {
            _logger = logger;
        }

        public void OnGet()
        {
        }
    }

}
