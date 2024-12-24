namespace Estudo1.External;

public class EmailProviderY
{
    public string SendEmail(string dest, string title, string body)
    {
        return $"Email \"{title}\" sent to {dest}";
    }
}