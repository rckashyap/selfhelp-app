namespace SelfHelp.API.Extensions;

public static class ConfigurationBuilderExtensions
{
    public static void AddConfigAndEnvironmentVariables(this IConfigurationBuilder config, IHostEnvironment env)
    {
        config.SetBasePath(env.ContentRootPath);
        config.AddJsonFile("appsettings.json", optional: false, reloadOnChange: true);
        config.AddJsonFile($"appsettings.{env.EnvironmentName}.json", optional: true, reloadOnChange: true);
        config.AddJsonFile("overrides/appsettings.json", optional: true, reloadOnChange: true);
        config.AddKeyPerFile("/app/overrides/keys", optional: true, reloadOnChange: true);
        config.AddEnvironmentVariables();
    }
}