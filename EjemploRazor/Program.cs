using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using EjemploRazor.Data;
using EjemploRazor;

// Comentario para GIt
var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddRazorPages();

// SqlServer
//builder.Services.AddDbContext<EjemploRazorContext>(options =>
//    options.UseSqlServer(builder.Configuration.GetConnectionString("EjemploRazorContext")));
// MySql
builder.Services.AddDbContext<EjemploRazorContext>();

var app = builder.Build();

// Aquí pondría mi código
if (FuncionesProgram.Context.Especializacion.Count() == 0)
{
    FuncionesProgram.LeerEspecializacionesPro();
}


// Fín de mi código

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Error");
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}

app.UseHttpsRedirection();
app.UseStaticFiles();

app.UseRouting();

app.UseAuthorization();

app.MapRazorPages();

app.Run();
