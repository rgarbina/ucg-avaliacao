
using Microsoft.EntityFrameworkCore;
using System.Text.Json.Serialization;
using UCG.Service.Avaliacao.Data;
using UCG.Service.Avaliacao.Repositorios.Interfaces;
using ucg_avaliacao.Server.Repositorios;

namespace UCG.Service.Avaliacao
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            builder.Services.AddControllers().AddJsonOptions(x =>
                {
                    x.JsonSerializerOptions.PropertyNameCaseInsensitive = true;
                    x.JsonSerializerOptions.ReferenceHandler = ReferenceHandler.IgnoreCycles;
                });
            builder.Services.AddEndpointsApiExplorer();
            builder.Services.AddSwaggerGen();
            builder.Services.AddEntityFrameworkSqlServer()
                .AddDbContext<UcgAvaliacaoDbContext>(
                    options => options.UseSqlServer(builder.Configuration.GetConnectionString("Avaliacao"))
                );

            builder.Services.AddScoped<IPessoaRepositorio, PessoaRepositorio>();

            var app = builder.Build();

            app.UseDefaultFiles();
            app.UseStaticFiles();

            if (app.Environment.IsDevelopment())
            {
                app.UseSwagger();
                app.UseSwaggerUI();
            }

            app.UseHttpsRedirection();
            app.UseAuthorization();
            app.MapControllers();
            app.MapFallbackToFile("/index.html");
            app.Run();
        }
    }
}
