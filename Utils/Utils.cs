namespace crudpcapi.Utils;

public class Utils
{
}

public static class ExtensionMethods
{
    public static string CompleteErroMessage(this Exception e)
    {
        var msg = e.Message;
        if (e.InnerException != null)
        {
            msg += " - " + e.InnerException.Message;
        }
        return msg;
    }
}