using BookClub.BLL.Interfaces;
using BookClub.BLL.Services;
using BookClub.DAL.EF;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddControllersWithViews();
builder.Services.AddHttpContextAccessor();

builder.Services.AddDbContext<BookClubContext>();

builder.Services.AddScoped<IUserService, UserService>();
builder.Services.AddScoped<IReadingRoomService, ReadingRoomService>();

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