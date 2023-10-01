using Microsoft.EntityFrameworkCore;
using Universites.Repositories.Interfaces;
using Universites.Repositories.Models;
using Universites.Repositories.Repositories;
using Universities.Services.Interfaces;
using Universities.Services.Services;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddDbContext<UniversitiesContext>(opt =>
    opt.UseSqlServer(builder.Configuration.GetConnectionString("UniversityDatabase"), b => b.MigrationsAssembly("Universities.API")));

builder.Services.AddMvc();

builder.Services.AddScoped<IUniversitiesRepository,UniversityRepository>();
builder.Services.AddScoped<IUniversitiesServices, UniversitiesServices>();

builder.Services.AddScoped<IDepartmentsRepository, DepartmentRepository>();
builder.Services.AddScoped<IDepartmentsServices, DepartmentsServices>();

builder.Services.AddScoped<ICoursesRepository, CourseRepository>();
builder.Services.AddScoped<ICoursesServices, CoursesServices>();

builder.Services.AddTransient<IUniversitiesContext, UniversitiesContext>();

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();

app.UseCors(x => x
                    .AllowAnyMethod()
                    .AllowAnyHeader()
                    .SetIsOriginAllowed(origin => true) // allow any origin
                    .AllowCredentials()); // allow credentials
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
