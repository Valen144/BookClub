using BookClub.BLL.Interfaces;
using BookClub.BLL.Services;

var builder = WebApplication.CreateBuilder(args);

IServiceCreator serviceCreator = new ServiceCreator();
// Add services to the container.
builder.Services.AddControllersWithViews();
builder.Services.AddHttpContextAccessor();
builder.Services.AddTransient<IUserService>(x => serviceCreator.CreateUserService());
builder.Services.AddTransient<IReadingRoomService>(x => serviceCreator.CreateReadingRoomService());

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
    pattern: "{controller=Account}/{action=Login}/{id?}");

app.Run();
