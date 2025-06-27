using Microsoft.EntityFrameworkCore;
using TechSummary.Interface;
using TechSummary.Models;
using TechSummary.Service;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddDbContext<TechSummaryContext>(options =>

    options.UseSqlServer("Data Source=DESKTOP-E8UDJO1;Initial Catalog=TechSummary;Integrated Security=True;Trust Server Certificate=True"));

builder.Services.AddScoped<IAuthService, AuthService>();
builder.Services.AddScoped<IAdminPanel, AdminPanelService>();
builder.Services.AddScoped<ICategoryService, CategoryService>();
builder.Services.AddScoped<IContentFilterService, ContentFilterService>();


var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
