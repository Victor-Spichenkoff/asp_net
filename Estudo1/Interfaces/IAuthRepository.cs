namespace Estudo1.Interfaces;

public interface IAuthRepository
{
    public string MakeLogin(string email, string password);
    // deveria ter criação user
}