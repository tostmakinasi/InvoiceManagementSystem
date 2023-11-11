using InvoiceManagement.Core.Models;
using InvoiceManagement.Core.OptionsModels;
using InvoiceManagement.Core.Repositories;
using InvoiceManagement.Core.Services;
using InvoiceManagement.Core.UnitOfWorks;
using InvoiceManagement.Repository;
using InvoiceManagement.Repository.Repositories;
using InvoiceManagement.Repository.UnitOfWorks;
using InvoiceManagement.Services.Mapping;
using InvoiceManagement.Services.Services;
using InvoiceManagement.Web.Extensions;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.FileProviders;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllersWithViews();
builder.Services.AddDbContext<AppDbContext>(options =>
{
    options.UseSqlServer(builder.Configuration.GetConnectionString("SqlCon"));
});

builder.Services.AddSingleton<IFileProvider>(new PhysicalFileProvider(Directory.GetCurrentDirectory()));
builder.Services.AddIdentityWithExtension();
builder.Services.AddCookieWithExtension();

builder.Services.AddAutoMapper(typeof(MapProfile));

builder.Services.AddScopedWithExtension();

builder.Services.Configure<EmailSettings>(builder.Configuration.GetSection("EmailSettings"));



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



app.MapControllerRoute(
    name: "areas",
    pattern: "{area:exists}/{controller=Home}/{action=Index}/{id?}");

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}");

app.Run();
