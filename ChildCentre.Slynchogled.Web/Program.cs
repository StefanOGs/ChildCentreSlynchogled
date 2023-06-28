using ChildCentre.Slynchogled.Web;

var builder = WebApplication.CreateBuilder(args);

builder.WebHost.UseIIS();

// Add services to the container.
builder.Services.AddControllersWithViews();

ServicesMap.AddServiceDependencies(builder);

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
    name: "default",
    pattern: "{controller=Dashboard}/{action=Index}/{id?}");

app.Run();

// TODO HH: Infrastructure
// 1. Add logging (text?)
// 2. Add exception handling (error view?)