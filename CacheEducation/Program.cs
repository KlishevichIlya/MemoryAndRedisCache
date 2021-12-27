using CacheEducation.Data;
using CacheEducation.Services.Author;
using Microsoft.EntityFrameworkCore;


var builder = WebApplication.CreateBuilder(args);
var connection = builder.Configuration.GetConnectionString("Default");


builder.Services.AddControllers();
builder.Services.AddDbContext<ApplicationContext>(options => options.UseSqlServer(connection));
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddTransient<IAuthorService, AuthorService>();
builder.Services.AddSwaggerGen();

var app = builder.Build();


if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
