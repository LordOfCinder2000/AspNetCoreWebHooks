using Microsoft.AspNetCore.Mvc;

namespace Microsoft.AspNetCore.WebHooks.Receivers.AntMedia.Test;

public class Program
{
    public static void Main(string[] args)
    {
        var builder = WebApplication.CreateBuilder(args);

        // Add services to the container.

        //builder.Services.AddControllers();
        builder.Services.AddMvc().AddNewtonsoftJson().AddAntMediaWebHooks();
        // Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
        //builder.Services.AddEndpointsApiExplorer();
        //builder.Services.AddSwaggerGen();
        builder.Services.Configure<MvcOptions>(opts =>
        {
            opts.EnableEndpointRouting = false;
        });
        var app = builder.Build();

        //// Configure the HTTP request pipeline.
        //if (app.Environment.IsDevelopment())
        //{
        //    app.UseSwagger();
        //    app.UseSwaggerUI();
        //}

        //app.UseHttpsRedirection();

        //app.UseAuthorization();

        app.UseMvc();
        //app.MapControllers();

        app.Run();
    }
}
