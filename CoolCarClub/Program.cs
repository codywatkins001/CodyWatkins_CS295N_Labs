using RecipeManager.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Identity;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllersWithViews();

var baseConnectionString = builder.Configuration.GetConnectionString("MySqlConnection");
var user = builder.Configuration["DbUser"];
var password = builder.Configuration["DbPassword"];
var connectionString = $"{baseConnectionString}userid={user};password={password};";

builder.Services.AddDbContext<RecipeManagerDbContext>(options =>
    options.UseMySQL(connectionString));

builder.Services.AddDefaultIdentity<IdentityUser>(options =>
    options.SignIn.RequireConfirmedAccount = true)
    .AddEntityFrameworkStores<RecipeManagerDbContext>();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Home/Error");
    app.UseHsts();
}

app.UseHttpsRedirection();
app.UseRouting();

app.UseAuthentication();
app.UseAuthorization();

app.MapStaticAssets();

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}")
    .WithStaticAssets();

using (var scope = app.Services.CreateScope())
{
    var dbContext = scope.ServiceProvider.GetRequiredService<RecipeManagerDbContext>();
    SeedData.Initialize(dbContext);
}

app.Run();