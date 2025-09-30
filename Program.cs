var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddRazorPages();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Error");
    // Active HSTS uniquement en prod
    app.UseHsts();
}

app.UseHttpsRedirection();
app.UseStaticFiles();

// 🔐 Security headers
app.Use(async (context, next) =>
{
    context.Response.Headers.TryAdd("Content-Security-Policy",
        "default-src 'self'; " +
        "img-src 'self' data: https:; " +
        "script-src 'self' 'unsafe-inline' https://cdnjs.cloudflare.com; " +
        "style-src 'self' 'unsafe-inline' https://cdnjs.cloudflare.com; " +
        "font-src 'self' https://cdnjs.cloudflare.com data:; " +
        "frame-ancestors 'none';");

    context.Response.Headers.TryAdd("X-Frame-Options", "DENY");
    context.Response.Headers.TryAdd("Cross-Origin-Opener-Policy", "same-origin");

    await next();
});


app.UseRouting();

app.UseAuthorization();

app.MapGet("/", context => {
    context.Response.Redirect("/Home/Index");
    return Task.CompletedTask;
});

app.MapRazorPages();

app.Run();
