using Microsoft.EntityFrameworkCore;
using Microsoft.OpenApi.Models;
using UserService.Api.Data;
using UserService.Api.Repositories;

var builder = WebApplication.CreateBuilder(args);

// Add builder.Services to the container.
builder.Services.AddCors(options =>
{
    options.AddPolicy("AllowAllHeaders",
          builder =>
          {
              builder.AllowAnyOrigin()
                     .AllowAnyHeader()
                     .AllowAnyMethod();
          });
});

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddSwaggerGen(c =>
{
    c.SwaggerDoc("v1", new OpenApiInfo { Title = "UserService.Api", Version = "v1" });
});

builder.Services.AddScoped<IUserRepository, UserRepository>(); 
builder.Services.AddDbContext<UserContext>(opt => opt.UseInMemoryDatabase("UserServiceDB"));

var app = builder.Build();

// Configure the HTTP request pipeline.
//if (app.Environment.IsDevelopment())
//{
    app.UseSwagger();
    app.UseSwaggerUI(c => c.SwaggerEndpoint("/swagger/v1/swagger.json", "UserService.Api v1"));
//}

app.UseHttpsRedirection();

app.UseRouting();

app.UseCors("AllowAllHeaders"); 

app.UseAuthorization();

app.UseEndpoints(endpoints =>
{
    endpoints.MapControllers();
});

app.Run();
