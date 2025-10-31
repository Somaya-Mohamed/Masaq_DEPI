
using BusinessAccessLayes;
using BusinessAccessLayes.Mapping_Profiles;
using BusinessAccessLayes.ServiceManagers;
using BusinessAccessLayes.Services.Classes;
using BusinessAccessLayes.Services.Interfaces;
using BusinessAccessLayes.Settings;
using DataAccessLayer.Contracts;
using DataAccessLayer.Data;
using DataAccessLayer.Data.Contexts;
using DataAccessLayer.Models.IdentityModels;
using DataAccessLayer.Repositories.UnitOfWork;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;
using System.Text;

namespace Masaq_app
{
    public class Program
    {
        public static async Task Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);



            // Add services to the container.

            builder.Services.AddControllers();
            // Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
            builder.Services.AddEndpointsApiExplorer();
            builder.Services.AddSwaggerGen();


            //register identity 
            builder.Services.AddIdentity<ApplicationUser, IdentityRole>(config =>
            {
                config.User.RequireUniqueEmail = true;
                config.Password.RequiredLength = 6;
                config.Password.RequireNonAlphanumeric = false;
                config.Password.RequireDigit = false;
                config.Password.RequireLowercase = false;
                config.Password.RequireUppercase = false;

            }).AddEntityFrameworkStores<MasaqDbContext>()
              .AddDefaultTokenProviders();

            #region EmailSetting
            builder.Services.Configure<EmailSettings>(
            builder.Configuration.GetSection("EmailSettings"));
            builder.Services.AddScoped<IEmailService, EmailService>();

            #endregion
            builder.Services.AddDbContext<MasaqDbContext>(options =>
           {
               options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection"));

           });


            var jwtoptions = builder.Configuration.GetSection("Jwt");

            builder.Services.AddAuthentication(config =>
            {
                config.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
                config.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;

            }).AddJwtBearer(conf =>
            {
                conf.TokenValidationParameters = new TokenValidationParameters()
                {
                    ValidateIssuer = true,
                    ValidIssuer = jwtoptions["Issuer"],
                    ValidateAudience = true,
                    ValidAudience = jwtoptions["Audience"],
                    ValidateLifetime = true,
                    ValidateIssuerSigningKey = true,
                    IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(jwtoptions["Key"]))
                };

            });



            builder.Services.AddScoped<IDataSeeding, DataSeeding>();
            builder.Services.AddScoped<ILessonService, LessonService>();
            builder.Services.AddAutoMapper(cong => cong.AddProfile(new LessonProfile()), typeof(AssembblyReference).Assembly);
            builder.Services.AddScoped<IServiceManager, ServiceManager>();
            builder.Services.AddScoped<IUnitOfWork, UnitOfWork>();
            builder.Services.AddScoped<IRoleService, RoleService>();

            var app = builder.Build();

            #region Data seeding
            var scope = app.Services.CreateScope();
            var seed = scope.ServiceProvider.GetRequiredService<IDataSeeding>();
            await seed.DataSeed();
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
