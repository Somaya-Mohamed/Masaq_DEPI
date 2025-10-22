
using BusinessAccessLayes.Mapping_Profiles;
using BusinessAccessLayes.ServiceManagers;
using BusinessAccessLayes.Services.Classes;
using BusinessAccessLayes.Services.Interfaces;
using DataAccessLayer.Contracts;
using DataAccessLayer.Data;
using Microsoft.OpenApi.Models;

using DataAccessLayer.Data.Contexts;
using DataAccessLayer.Repositories.UnitOfWork;
using Microsoft.EntityFrameworkCore;
using System.Reflection.Metadata;

namespace Masaq_APP
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            // Add services to the container.

            builder.Services.AddControllers();
            builder.Services.AddEndpointsApiExplorer();
           builder.Services.AddSwaggerGen(c =>
{
    c.SwaggerDoc("v1", new Microsoft.OpenApi.Models.OpenApiInfo
    {
        Title = "Masaq API",
        Version = "v1"
    });
});


            builder.Services.AddDbContext<MasaqDbContext>(options =>
            {
                options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection"));

            }
           );
            builder.Services.AddScoped<IDataSeeding, DataSeeding>();
            builder.Services.AddScoped<ILessonService, LessonService>();
            builder.Services.AddAutoMapper(cong => cong.AddProfile(new LessonProfile()), typeof(AssemblyReference).Assembly);
            builder.Services.AddScoped<IServiceManager, ServiceManager>();
            builder.Services.AddScoped<IUnitOfWork, UnitOfWork>();
            
           

            var app = builder.Build();
            #region Data seeding
            var scope = app.Services.CreateScope();
            var seed = scope.ServiceProvider.GetRequiredService<IDataSeeding>();
            seed.DataSeed();
            #endregion

            // Configure the HTTP request pipeline.
            if (app.Environment.IsDevelopment())
            {
                app.UseSwagger();
                app.UseSwaggerUI();
            }


            app.UseHttpsRedirection();
            app.UseStaticFiles();

            app.UseAuthorization();


            app.MapControllers();

            app.Run();
        }
    }
}
