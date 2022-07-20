namespace MinimalApi.Configuration;

public static class ConfigurationFactory
{
    private static string SECTION_NAME = "MinimalApiConfiguration";

    public static MinimalApiConfiguration Create(IConfiguration configuration) =>
        configuration.GetSection(SECTION_NAME).Get<MinimalApiConfiguration>();
}