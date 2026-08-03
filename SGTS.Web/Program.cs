using Microsoft.EntityFrameworkCore;
using SGTS.Business.Interfaces;
using SGTS.Business.Interfaces.Administracion;
using SGTS.Business.Services;
using SGTS.Business.Services.Administracion;
using SGTS.Data.Context;
using SGTS.Data.Interfaces;
using SGTS.Data.Interfaces.Administracion;
using SGTS.Data.Repositories;
using SGTS.Data.Services;
using SGTS.Web.Filters;
using SGTS.Web.Middleware;

var builder = WebApplication.CreateBuilder(args);
builder.Services.AddScoped<IDepartamentosRepository, DepartamentosRepository>();
builder.Services.AddScoped<IDepartamentoService, DepartamentoService>();
builder.Services.AddScoped<IUsuarioAsignacionRepository, UsuarioAsignacionRepository>();
builder.Services.AddScoped<IUsuarioAsignacionService, UsuarioAsignacionService>();
builder.Services.AddScoped<IRolRepository, RolRepository>();
builder.Services.AddScoped<IRolService, RolService>();

builder.Services.AddScoped<DataTableQueryService>();

builder.Services.AddControllersWithViews(options =>
{
    options.Filters.Add<ValidateModelFilter>();
});

builder.Services.AddControllers()
    .AddJsonOptions(options =>
    {
        options.JsonSerializerOptions.DefaultIgnoreCondition =
            System.Text.Json.Serialization.JsonIgnoreCondition.WhenWritingNull;
    });

var connectionString = builder.Configuration.GetConnectionString("DefaultConnection");

builder.Services.AddDbContext<AppDbContext>(options =>
    options.UseSqlServer(connectionString));


var app = builder.Build();
app.UseMiddleware<ExceptionMiddleware>();

if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Home/Error");
    app.UseHsts();
}

app.UseHttpsRedirection();
app.UseRouting();

app.UseAuthorization();

app.UseStaticFiles();

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}")
    .WithStaticAssets();

app.Run();
