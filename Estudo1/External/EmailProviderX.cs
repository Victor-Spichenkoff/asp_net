namespace Estudo1.External;

// portugues e params
public class EmailProviderX
{
    public string EnviarEmail(string dest, string corpo, string titulo)
    {
        return $"Email \"{titulo}\" enviado para {dest}";
    }
}