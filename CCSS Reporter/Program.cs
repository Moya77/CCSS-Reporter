using CCSS_Reporter.DB;
using CCSS_Reporter.Services;
using NLog.Web;


var builder = WebApplication.CreateBuilder(args);


builder.Host.ConfigureLogging(logging =>
{
    logging.ClearProviders();
    logging.SetMinimumLevel(LogLevel.Trace);
})
.UseNLog();

builder.Services.AddHttpClient();
builder.Services.AddTransient<EmailService>();
builder.Services.AddControllersWithViews();
builder.Services.AddRazorPages();
builder.Services.AddMemoryCache();

builder.Services.AddScoped<ICommandRegProfesional, CommandRegProfesional>();
builder.Services.AddScoped<IQueryGetProfesional, QueryGetProfesional>();
builder.Services.AddScoped<ICommandRegClinica, CommandRegClinica>();
builder.Services.AddScoped<IQueryGetClinica, QueryGetClinica>();
builder.Services.AddScoped<IQueryGetPaciente, QueryGetPaciente>();
builder.Services.AddScoped<ICommandRegPaciente, CommandRegPaciente>();
builder.Services.AddScoped<ICommandRegInyeccion, CommandRegInyeccion>();
builder.Services.AddScoped<ICommandRegSintomasPaciente, CommandRegSintomasPaciente>();

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
    pattern: "{controller=Home}/{action=Index}/{id?}");

app.Run();
