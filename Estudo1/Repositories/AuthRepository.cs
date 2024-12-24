using Estudo1.Helpers;
using Estudo1.Interfaces;
using Estudo1.Services;

namespace Estudo1.Repositories;

public class AuthRepository(IUserRepository ur): IAuthRepository
{
    private readonly IUserRepository _userRepository = ur;
    
    /*
     * Retorna o token ou erro
     */
    public string MakeLogin(string email, string password)
    {
        var user = _userRepository.GetUserByEmail(email);
        
        if(user == null)
            throw new GenericApiError("Usuário inexistente", 403);

        // deveria comparar com criptografia
        if (!user.Password.Equals(password))
            throw new GenericApiError("Senha incorreta", 403);



        // criar token

        //meu
        var token = TokenService.GenerateToken( user.Id, email);
        return token;
    }
}