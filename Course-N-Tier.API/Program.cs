
using Course_N_Tier.BLL.Manager;
using Course_N_Tier.BLL.Middlewares;
using Course_N_Tier.DAL.Database;
using Course_N_Tier.DAL.Repository;
using Microsoft.AspNetCore.RateLimiting;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Options;
using Scalar.AspNetCore;
using System.Threading.RateLimiting;

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

            // Rate Limiting Service
            builder.Services.AddRateLimiter(options =>
            {
                options.AddFixedWindowLimiter("FixedPolicy", opt =>
                {
                    opt.PermitLimit = 5;
                    opt.Window = TimeSpan.FromSeconds(10);
                    opt.QueueProcessingOrder = QueueProcessingOrder.OldestFirst;
                    opt.QueueLimit = 2;
                });
            });

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

            app.UseRateLimiter();

            // all controllers will use this policy
            app.MapControllers().RequireRateLimiting("FixedPolicy");

            app.UseMiddleware<GlobalExceptionMiddleware>();

            app.UseHttpsRedirection();

            app.UseAuthorization();


            app.MapControllers();

            app.Run();
        }
    }
}
