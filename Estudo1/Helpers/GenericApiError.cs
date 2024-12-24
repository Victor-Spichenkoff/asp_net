namespace Estudo1.Helpers;

public class GenericApiError : Exception
{
    public new string Message = string.Empty;
    public int StatusCode = 500;

    public GenericApiError(string message, int statusCode)
    {
        Message = message;
        if (statusCode is >= 100 and < 560)
        {
            StatusCode = statusCode;
        }
    }
}