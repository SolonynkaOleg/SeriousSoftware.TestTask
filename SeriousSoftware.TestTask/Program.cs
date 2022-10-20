using SeriousSoftware.Services.ExternalAPIs;
using SeriousSoftware.Services;
using SeriousSoftware.Data.Repositories;
using System.Text;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllersWithViews();
builder.Services.AddScoped<IStockPriceRepository, StockPriceRepository>();
builder.Services.AddScoped<IPerformanceCalculator, PerformanceCalculator>();
builder.Services.AddAutoMapper(typeof(Program));
builder.Services.Configure<PolygonApiSettings>(builder.Configuration.GetSection("PolygonApi"));

builder.Services.AddHttpClient<PolygonApi>();
builder.Services.AddScoped<IPolygonApi, PolygonApi>();
builder.Services.AddCors();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}

app.UseCors(x => x.AllowAnyMethod()
                .AllowAnyHeader()
                .SetIsOriginAllowed(origin => true) // allow any origin
                .AllowCredentials());

app.UseHttpsRedirection();
app.UseStaticFiles();
app.UseRouting();

app.MapControllerRoute(
    name: "default",
    pattern: "{controller}/{action}/{id?}");

app.Run();
