using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using ChineseZodiacLab1.Models;
using System.Formats.Tar;

namespace ChineseZodiacLab1.Pages
{
    public class IndexModel : PageModel
    {
        private readonly ILogger<IndexModel> _logger;

        public IndexModel(ILogger<IndexModel> logger)
        {
            _logger = logger;
        }

        public IActionResult OnPost()
        {
            // Handle the "Get Zodiac" button click here.
            // You can access form data, process it, and return a response.

            int userInput = Int32.Parse(Request.Form["userInput"]);

            if (userInput >= 1900 && userInput <= DateTime.Now.Year + 1)
            {
                string zodiac = Utils.GetZodiac(userInput);
                ViewData["ImageSource"] = Url.Content($"~/images/{zodiac.ToLower()}.png");
                ViewData["ZodiacName"] = zodiac;
            }
            else
            {
                ViewData["ErrorMessage"] = "Year must be between 1900 and next year. Please try again.";
            }
            

            return Page();
        }

        public void OnGet()
        {

        }

        public IActionResult OnPostClear()
        {
            // Clear any form fields or reset data here.

            // For example, if you want to clear the userInput field:
            ViewData["userInput"] = string.Empty;

            // Clear any error messages.
            ViewData["ErrorMessage"] = string.Empty;

            // Clear the image source.
            ViewData["ImageSource"] = string.Empty;

            // Redirect back to the page to display the cleared form.
            return RedirectToPage();
        }
    }
}