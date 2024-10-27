var builder = WebApplication.CreateBuilder(args);

// Razor Pages desteği ekleniyor
builder.Services.AddRazorPages();

var app = builder.Build();

// Razor Pages routing yapılandırması
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
