using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace WebRazorApp.Pages.Account;

public class LoginModel : PageModel
{
     
    [BindProperty(SupportsGet = false)]
    public string username { get; set; }

    [BindProperty(SupportsGet = false)]
    public string password { get; set; }

    public string ErrorMessage { get; set; }
    public IActionResult OnGet()
    {
        return Page();
    }

    public async Task<IActionResult> OnPostAsync()
    {
        try
        {
            var httpClient = new HttpClient();
            var requestContent = new StringContent(
                System.Text.Json.JsonSerializer.Serialize(new { username = username, password = password }),
                System.Text.Encoding.UTF8,
                "application/json");

            var response = await httpClient.PostAsync("https://localhost:7254/api/auth/login", requestContent);

            if (response.IsSuccessStatusCode)
            {
                var token = await response.Content.ReadAsStringAsync();

                var cookieOptions = new CookieOptions
                {
                    HttpOnly = false, // JavaScript'ten eriþilebilir olmasý için
                    Secure = true,
                    SameSite = SameSiteMode.Strict,
                    Expires = DateTime.Now.AddHours(1)
                };

                Response.Cookies.Append("authTokenRazor", token, cookieOptions); // authTokenRazor olarak deðiþtirildi

                // Farklý redirect yöntemlerini deneyelim
                Console.WriteLine("Redirecting to Index...");

                // 1. yöntem:
                return Redirect("~/");

                // veya 2. yöntem:
                // return LocalRedirect("~/");

                // veya 3. yöntem:
                // return Redirect("/Index");

                // veya 4. yöntem:
                // return RedirectToPage("Index");
            }
            else
            {
                ErrorMessage = "Giriþ baþarýsýz. Lütfen bilgilerinizi kontrol edin.";
                return Page();
            }
        }
        catch (Exception ex)
        {
            Console.WriteLine($"Exception: {ex.Message}");
            ErrorMessage = "Bir hata oluþtu. Lütfen daha sonra tekrar deneyin.";
            return Page();
        }
    }
}
