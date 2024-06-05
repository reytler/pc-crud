namespace crudpcapi;

public class Config
{
    public static bool DEBUG;

    public static void LoadConfig(IConfiguration configuration)
    {
        Config.DEBUG = bool.TryParse(configuration["DEBUG"], out bool debug) ? debug : false;
    }

    public static string Secret = "43e4dbf0-52ed-4203-895d-42b586496bd4";
}
