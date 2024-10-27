using WebRazorApp.Middleware;

var builder = WebApplication.CreateBuilder(args);

// Razor Pages deste�i ekleniyor
builder.Services.AddRazorPages();
 

var app = builder.Build();
// Giri� kontrol� i�in middleware ekleyin
app.UseTokenCheck();
// Razor Pages routing yap�land�rmas�
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Error");
    app.UseHsts();
}

app.UseHttpsRedirection();
app.UseStaticFiles();

app.UseRouting();

app.UseAuthorization();

app.MapRazorPages();

app.Run();
