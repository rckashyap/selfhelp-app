﻿using Microsoft.Extensions.Primitives;

namespace SelfHelp.API
{
    public class Startup
    {
        /// <summary>
        /// Gets the configuration object.
        /// </summary>
        private readonly IConfiguration configuration;

        /// <summary>
        /// Initializes a new instance of the <see cref="Startup"/> class.
        /// </summary>
        /// <param name="configuration"><see cref="IConfiguration"/>.</param>
        public Startup(IConfiguration configuration)
        {
            this.configuration = configuration;
        }

        /// <summary>
        /// This method gets called by the runtime. Use this method to add services to the container.
        /// </summary>
        /// <param name="services"><see cref="IServiceCollection"/>.</param>
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddEndpointsApiExplorer();
            services.AddSwaggerGen();
            services.AddControllers();
            services.AddHttpClient();
        }

        /// <summary>
        /// This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        /// </summary>
        /// <param name="app">Application's request pipeline builder.</param>
        /// <param name="hostingEnvironment">Hosting environment.</param>
        /// <param name="lifetime">The host application lifetime instance.</param>
        /// <param name="logger">The logger instance.</param>
        public void Configure(IApplicationBuilder app,
            IWebHostEnvironment hostingEnvironment,
            IHostApplicationLifetime lifetime,
            ILogger<IConfiguration> logger)
        {
            if (hostingEnvironment.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
                app.UseSwagger();
                app.UseSwaggerUI(c =>
                    {
                        c.SwaggerEndpoint("v1/swagger.json", "SelfHelpAPI");
                    });
            }

            app.UseRouting();
            app.UseHttpsRedirection();
            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });
            var disposable = ChangeToken.OnChange(
                () => this.configuration.GetReloadToken(),
                () => logger.LogInformation("Configuration file changed"));

            lifetime.ApplicationStopping.Register(() =>
            {
                disposable.Dispose();
            });
        }
    }
}