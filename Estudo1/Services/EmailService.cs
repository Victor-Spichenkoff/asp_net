using Estudo1.External;
using Estudo1.Interfaces;

namespace Estudo1.Services;

// usar X
public class EmailService: IEmailService
{
    public string MandarEmail(string dest, string titulo, string corpo)
    {
        // X, morreu!
        EmailProviderX provider = new();

        return provider.EnviarEmail(dest, corpo, titulo);
        // EmailProviderY provider = new ();
        // return provider.SendEmail(dest, titulo, corpo);
        //
    }
}