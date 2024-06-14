
using Persistencia.Entity;
using Persistencia.Services;
using Microsoft.EntityFrameworkCore;
using Persistencia;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllersWithViews();

builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

//builder.Services.AddPersistencia();
//*********************** Add services to the container.***********************
builder.Services.AddTransient<IGamerService, GamerService>();
//*********************** Add services to the container end.***********************

//*********************** Register DbContext and provide ConnectionString .***********************
builder.Services.AddDbContext<GamerDbContext>(db => db.UseSqlServer(builder.Configuration.GetConnectionString("ContextConnectionStrings")), ServiceLifetime.Singleton);
//*********************** Register DbContext end.***********************


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
    pattern: "{controller=Home}/{action=Index}/{id?}");
//Swagger
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}
app.Run();
