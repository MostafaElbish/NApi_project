using Microsoft.EntityFrameworkCore;
using Talabat.API.Entities;
using Talabat.repostry.Data;
using Talabat.repostry.Data.Configration;
using Talabat.repostry.Repostries;
using Talapat.Core.Reposters.Interfaces;

namespace Talabat.API
{
    public class Program
    {
     

        public static async void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            // Add services to the container.

            builder.Services.AddControllers();
            // Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
            builder.Services.AddEndpointsApiExplorer();
            builder.Services.AddSwaggerGen();
            builder.Services.AddDbContext<StoreDbcontext>(options =>
            {
                options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection"));
            });

            //builder.Services.AddScoped<IGenaricReopistres<Product>, GenaricReopistry<Product>>();
            // builder.Services.AddScoped<IGenaricReopistres<ProductCatugory>, GenaricReopistry<ProductCatugory>>();
            // builder.Services.AddScoped<IGenaricReopistres<Product>, GenaricReopistry<Product>>();
            builder.Services.AddScoped(typeof(IGenaricReopistres<>), typeof(GenaricReopistry<>));

            var app = builder.Build();
            var scope = app.Services.CreateScope();
            var services = scope.ServiceProvider;
            var context = services.GetRequiredService<StoreDbcontext>();

            var logerfactory = services.GetRequiredService<ILoggerFactory>();
            try
            {
               await context.Database.MigrateAsync();
              await  StoreDbcontexseed.seeedAcync(context);
               
            }
            catch (Exception ex)
            {
                var loger = logerfactory.CreateLogger<Program>();
                loger.LogError(ex, message: "an Error has been occured");

            }
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
        }
    }
}
