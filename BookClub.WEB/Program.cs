using BookClub.BLL.Interfaces;
using BookClub.BLL.Services;

var builder = WebApplication.CreateBuilder(args);

IServiceCreator serviceCreator = new ServiceCreator();

builder.Services.AddControllersWithViews();
builder.Services.AddHttpContextAccessor();
builder.Services.AddTransient<IUserService>(x => serviceCreator.CreateUserService());
builder.Services.AddTransient<IReadingRoomService>(x => serviceCreator.CreateReadingRoomService());

var app = builder.Build();

if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Home/Error");
    app.UseHsts();
}

app.UseHttpsRedirection();
app.UseStaticFiles();

app.UseRouting();

app.UseAuthorization();

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Account}/{action=Login}/{id?}");

app.Run();
