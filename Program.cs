using FastCommissionBack.Data;
using FastCommissionBack.Repositories;
using FastCommissionBack.Services;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddDbContext<AppDbContext>(opt =>
  opt.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection")));

builder.Services.AddCors(options =>
{
    options.AddPolicy("AllowFrontend", policy =>
    {
        policy
          .WithOrigins("https://comisi-nfrontend.onrender.com", "http://localhost:3000")
          .AllowAnyMethod()
          .AllowAnyHeader();
    });
});

builder.Services.AddScoped<IVentaRepository, VentaRepository>();
builder.Services.AddScoped<IComisionStrategy, ExactMatchStrategy>();
builder.Services.AddScoped<ComisionService>();


builder.Services.AddControllers();

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

app.UseCors("AllowFrontend");

app.UseAuthorization();

app.MapControllers();

app.Run();
