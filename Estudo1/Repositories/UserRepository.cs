using Estudo1.Data;
using Estudo1.Helpers;
using Estudo1.Interfaces;
using Estudo1.Models;

namespace Estudo1.Repositories;

public class UserRepository(DataContext ctx): IUserRepository
{
    private readonly DataContext _ctx = ctx;
    
    public List<User> GetAllUsers()
    {
        var users = _ctx.Users.ToList();
        
        return users;
    }

    public User GetUserById(int id)
    {
        var user = _ctx.Users.FirstOrDefault(u => u.Id == id);

        if (user == null)
            throw new GenericApiError("usuário inexistente", 404);
        
        return user;
    }

    public User? GetUserByEmail(string email)
    {
        return _ctx.Users.FirstOrDefault(u => u.Email == email);
    }

    public bool AddUser(User user)
    {
        _ctx.Users.Add(user);
        
        return _ctx.SaveChanges() > 0;
    }

    public bool USerExist(string email)
    {
        return _ctx.Users.Any(u => u.Email == email);
    }
}