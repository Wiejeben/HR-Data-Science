using Microsoft.AspNetCore.Mvc.RazorPages;

namespace Data_Mining.Pages
{
    public class IndexModel : PageModel
    {
        public string Message { get; set; }

        public void OnGet()
        {
            Message = "This is a test";
        }
    }
}