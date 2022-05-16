using Microsoft.AspNetCore.ResponseCompression;
using Oma.Server;
using Serilog;

var builder = WebApplication.CreateBuilder(args);


builder.Services.AddControllersWithViews();
builder.Services.AddRazorPages();

var startup = new Startup(builder.Configuration);
startup.ConfigureServices(builder.Services);
builder.Host.UseSerilog();

var app = builder.Build();

if (app.Environment.IsDevelopment())
{
    app.UseWebAssemblyDebugging();
}
else
{
    app.UseExceptionHandler("/Error");
    app.UseHsts();
}

app.UseHttpsRedirection();

app.UseBlazorFrameworkFiles();
app.UseStaticFiles();
app.UseSerilogRequestLogging();
app.UseRouting();
startup.InitDatabase(app);


app.MapRazorPages();
app.MapControllers();
app.MapFallbackToFile("index.html");

app.Run();
