public class Startup
{
    public void ConfigureServices(IServiceCollection services)
    {
        services.AddControllers();

        // Configurar Blob e Table Storage
        services.AddSingleton(x => new BlobServiceClient(Configuration["AzureStorage:ConnectionString"]));
        services.AddSingleton(x => new TableServiceClient(Configuration["AzureStorage:ConnectionString"]));
    }

    public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
    {
        if (env.IsDevelopment())
        {
            app.UseDeveloperExceptionPage();
        }

        app.UseRouting();
        app.UseEndpoints(endpoints =>
        {
            endpoints.MapControllers();
        });
    }
}
