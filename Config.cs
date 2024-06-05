namespace crudpcapi;

public class Config
{
    public static bool DEBUG;

    public static void LoadConfig(IConfiguration configuration)
    {
        Config.DEBUG = bool.TryParse(configuration["DEBUG"], out bool debug) ? debug : false;
    }
}
