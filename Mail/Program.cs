using Mail.DAL;
using Mail.DAL.Repositories;
using Mail.Domain.Interfaces.Repositories;
using Mail.Domain.Interfaces.Services;
using Mail.Service.Implementation;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddDbContext<ApplicationDbContext>(options => options.UseNpgsql(
 builder.Configuration.GetConnectionString("DefaultConnection")
    ));

// Add services to the container.
builder.Services.AddControllers();
builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddTransient<ILetterService, LetterService>();
builder.Services.AddTransient<ILetterRepository, LetterRepository>();

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



