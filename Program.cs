using Microsoft.EntityFrameworkCore;
using MSSA_Assignment_12._2.Services;
using MSSA_Assignment_12._2.Models;


var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllersWithViews();
//builder.Services.AddSingleton<ICRUD, CRUDRepository>(); //working with collections

builder.Services.AddScoped<ICRUD, DbCrud>(); // to work with db
builder.Services.AddScoped<IFileUpload, FileUpload>();
//builder.Services.AddDbContext<EmployeeContext>(options => options.UseSqlite("Data Source=CCAD9Employees.db")); // Code First

builder.Services.AddDbContext<BookContext>(options => options.UseSqlServer("Server=DESKTOP-KT4Q12B\\SQLEXPRESS;Database=MangaShop;TrustServerCertificate=True; Trusted_Connection=true;MultipleActiveResultSets=True"));


var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Home/Error");
}
using (var scope = app.Services.CreateScope())
{
    var dbcontext = scope.ServiceProvider.GetRequiredService<BookContext>();
    dbcontext.Database.EnsureCreated(); // create the db
}
app.UseStaticFiles();

app.UseRouting();

app.UseAuthorization();

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}");

app.Run();
