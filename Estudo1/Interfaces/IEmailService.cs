namespace Estudo1.Interfaces;

public interface IEmailService
{
    public string MandarEmail(string dest, string titulo, string corpo);
}