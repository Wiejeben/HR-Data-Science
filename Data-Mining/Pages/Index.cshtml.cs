using System;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace Data_Mining.Pages
{
    public class IndexModel : PageModel
    {
        public string Message { get; set; }

        public void OnGet()
        {
            Message = "Data science exercies";
        }
    }
}