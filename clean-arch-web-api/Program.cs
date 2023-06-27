using clean_arch_web_api.Controllers;
using clean_arch_web_api.Domain.Entities;
using clean_arch_web_api.Domain.Interfaces.Usecases;
using clean_arch_web_api.Domain.Persintence;
using clean_arch_web_api.Domain.Usecases;
using CleanArch.Domain.Database;
using CleanArch.Domain.Entities;
using CleanArch.Domain.Interfaces.Database;
using CleanArch.Domain.Interfaces.Repository;
using CleanArch.Domain.Interfaces.Usecases;
using CleanArch.Persintence;
using CleanArch.Usecases;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using System.Data;
using static CleanArch.Domain.Database.ConnectionGenerate;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();


builder.Services.AddSingleton<IConnectionManager, ConnectionManager>(provider => new ConnectionManager(DatabaseType.MySql));
builder.Services.AddScoped<IRepository<Course>, CourseRepository>();
builder.Services.AddScoped<IRepository<Student>, StudentRepository>();
builder.Services.AddScoped<IRepository<Registration>, RegistrationRepository>();
builder.Services.AddScoped<IRepository<Subject>, SubjectRepository>();
builder.Services.AddScoped<IRepository<CourseSubject>, CourseSubjectRepository>();
builder.Services.AddScoped<IRepository<Curriculum>, CurriculumRepository>();
builder.Services.AddScoped<IRepository<StudentSubject>, StudentSubjectRepository>();
builder.Services.AddScoped<IRegistrationRepository, RegistrationRepository>();
builder.Services.AddScoped<ICurriculumRepository, CurriculumRepository>();

//Usecases
builder.Services.AddScoped<ICourseUsecases, CourseUsecases>();
builder.Services.AddScoped<IStudentUsecases, StudentUsecases>();
builder.Services.AddScoped<IRegistrationUsecases, RegistrationUsecases>();
builder.Services.AddScoped<ISubjectUsecases, SubjectUsecases>();
builder.Services.AddScoped<ICurriculumUsecases, CurriculumUsecases>();
builder.Services.AddScoped<ICourseSubjectUsecases, CourseSubjectUsecases>();
builder.Services.AddScoped<IStudentSubjectUsecases, StudentSubjectUsecases>();

builder.Services.AddCors(options =>
{
    options.AddPolicy("AllowLocalhost",
        builder =>
        {
            builder.WithOrigins("http://localhost:5173")
                   .AllowAnyHeader()
                   .AllowAnyMethod();
        });
});

var app = builder.Build();

app.UseCors("AllowLocalhost");


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

