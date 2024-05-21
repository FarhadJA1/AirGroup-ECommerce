namespace C.Service.Utilities.Helpers;
public class InputHelper
{
    public static bool IsInputProper(string currentVariant, string newVariant)
    {
        if (!string.IsNullOrEmpty(newVariant) && currentVariant != newVariant)
            return true;

        return false;
    }
}
