using DownloadMusic.Models;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);
//var connectionString = builder.Configuration.GetConnectionString("MusicConnection");
// Add services to the container.
builder.Services.AddControllersWithViews();
builder.Services.AddDbContext<MusicDbContext>(o => o.UseSqlServer(builder.Configuration.GetConnectionString("MusicConnection")));

var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Home/Error");
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}

app.UseHttpsRedirection();
app.UseStaticFiles();

app.UseRouting();

app.UseAuthorization();


//app.MapControllerRoute(
//    name: "default",
//    pattern: "{controller=Home}/{action=Index}/{id?}");

app.UseEndpoints(endpoints =>
{
    // 1
    endpoints.MapControllerRoute(
        name: "area",
        pattern: "{area:exists}/{controller=Home}/{action=Index}/{id?}");

    // 2
    endpoints.MapAreaControllerRoute(
                       name: "default",
                       areaName: "MainDownload",
                       pattern: "{area=MainDownload}/{controller=Home}/{action=Index}/{id?}");

    endpoints.MapAreaControllerRoute(
            name: "MyAdmin",
            areaName: "Admin",
            pattern: "Admin/{controller=track}/{action=GetList}/{id?}");
});

app.Run();
