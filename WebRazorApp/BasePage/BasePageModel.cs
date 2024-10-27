using Microsoft.AspNetCore.Mvc.Filters;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace WebRazorApp.BasePage;

public class BasePageModel : PageModel, IPageFilter
{
    public void OnPageHandlerExecuting(PageHandlerExecutingContext context)
    {
        var token = Request.Cookies["authToken"]; // veya Header'dan alınabilir
        var currentPath = context.HttpContext.Request.Path.Value;

        // Eğer token yoksa ve kullanıcı login sayfasında değilse yönlendir
        if (string.IsNullOrEmpty(token) && !currentPath.Equals("/Account/Login", StringComparison.OrdinalIgnoreCase))
        {
            context.HttpContext.Response.Redirect("/Account/Login");
        }
    }

    public void OnPageHandlerExecuted(PageHandlerExecutedContext context)
    {
        // Gerekirse işlem sonrası kodlar
    }

    public void OnPageHandlerSelected(PageHandlerSelectedContext context)
    {
        // Gerekirse ek işlemler
    }
}