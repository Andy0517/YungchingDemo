using Microsoft.AspNetCore.Mvc.RazorPages;
using YungchingDemo.Comm;
using YungchingDemo.Models;

namespace YungchingDemo.Pages
{
    public class InsertModel : PageModel
    {
        private readonly IConfiguration _configuration;
        private readonly ILogger<InsertModel> _logger;
        public List<ComboBoxModel> _PTHouseType;

        public InsertModel(IConfiguration configuration, ILogger<InsertModel> logger)
        {
            _logger = logger;
            _configuration = configuration;
        }

        public void OnGet()
        {
            var ComboBox = new ComboBoxService(_configuration.GetSection("ConnectionStrings")["DefaultConnection"]);
            _PTHouseType = ComboBox.Get("HouseType");
        }
    }

}
