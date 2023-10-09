using Microsoft.EntityFrameworkCore;
using TengoProject.Domain.Abstracitions;
using TengoProject.Repository.DataContext;
using TengoProject.Repository.Implementations;
using TengoProject.Services.Abstraction;
using TengoProject.Services.Implementation;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
builder.Services.AddDbContext<DatabaseContext>(options =>
options.UseSqlServer(builder.Configuration.GetConnectionString("connectionString")));
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddCors(options =>
{
    options.AddPolicy("CorsPolicy",
    builder => builder.WithOrigins("http://localhost:3000", "http://localhost:5000")
   .AllowAnyMethod()
   .AllowAnyHeader());
});
builder.Services.AddScoped<ICrmService, CrmService>();
builder.Services.AddScoped<IUsersRepository, UsersRepository>();
builder.Services.AddScoped<IUnitOfWork, UnitOfWork>();
builder.Services.AddScoped<IUsersRepository, UsersRepository>();
builder.Services.AddScoped(typeof(IGenericReoisitory<>), typeof(GenericRepository<>));
builder.Services.AddScoped<IPasswordHasher, PasswordHasher>();
builder.Services.AddScoped<IJwtService, JwtService>();
builder.Services.AddScoped<IImagesRepository, ImagesRepository>();
var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();
app.UseCors("CorsPolicy");

app.UseAuthorization();

app.MapControllers();

app.Run();
