using FileManager;
using FileManager.Interface;
using Microsoft.Extensions.FileProviders;
using System.Reflection;

internal class Program
{
    private static void Main(string[] args)
    {
        var builder = WebApplication.CreateBuilder(args);

        builder.Services.AddCors(options =>
        {
            options.AddDefaultPolicy(
                policy =>
                {
                    policy.WithOrigins("*");
                });
        });

        var config = builder.Configuration;

        // Fileµù¥U
        builder.Services.AddTransient<IFileService, IFileService>((ctx) =>
            new FileServiceFactory(config).CreateUploadService()
        );

        // Add services to the container.

        builder.Services.AddControllers();
        // Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
        builder.Services.AddEndpointsApiExplorer();
        builder.Services.AddSwaggerGen();

        var app = builder.Build();

        // Configure the HTTP request pipeline.
        if (app.Environment.IsDevelopment())
        {
            app.UseSwagger();
            app.UseSwaggerUI();
        }

        app.UseHttpsRedirection();

        

        app.MapControllers();

        app.UseDefaultFiles();

        Assembly self = typeof(Program).Assembly;
        app.UseFileServer(new FileServerOptions
        {
            RequestPath = "",
            FileProvider = new ManifestEmbeddedFileProvider(self, "view")
        });

        app.UseStaticFiles();
        app.UseCors();
        app.UseRouting();

        app.UseAuthorization();

        app.UseEndpoints(endpoints =>
        {
            endpoints.MapControllers();
            endpoints.MapFallbackToFile("index.html"); // Fallback route
        });

        app.Run();
    }

}