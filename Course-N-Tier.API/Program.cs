
using Course_N_Tier.BLL.Manager;
using Course_N_Tier.DAL.Database;
using Course_N_Tier.DAL.Repository;
using Microsoft.EntityFrameworkCore;
using Scalar.AspNetCore;

namespace Course_N_Tier.API
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            // Add services to the container.

            builder.Services.AddControllers();
            // Learn more about configuring OpenAPI at https://aka.ms/aspnet/openapi
            builder.Services.AddOpenApi();
            builder.Services.AddDbContext<AppDbContext>(op =>
            {
                op.UseSqlServer(builder.Configuration.GetConnectionString("cs"));
            });
            // Register Repositories
            builder.Services.AddScoped<IStudentRepo, StudentRepo>();
            builder.Services.AddScoped<IInstructorRepo, InstructorRepo>();

            // Register Managers
            builder.Services.AddScoped<IStudentManger, StudentManger>();
            builder.Services.AddScoped<IInstructorManger, InstructorManger>();

            // Register Memory Cache
            builder.Services.AddMemoryCache();

            var app = builder.Build();

            // Configure the HTTP request pipeline.
            if (app.Environment.IsDevelopment())
            {
                app.MapOpenApi();
                app.MapScalarApiReference(options =>
                {
                    options.Title = "The DEPI-REALESTATE Api";
                    options.Layout = ScalarLayout.Classic;
                    options.HideClientButton = true;
                    options.Theme = ScalarTheme.Saturn;
                });
            }

            app.UseHttpsRedirection();

            app.UseAuthorization();


            app.MapControllers();

            app.Run();
        }
    }
}
