using Estudo1.Models;

namespace Estudo1.Interfaces;

public interface IUserRepository
{
    List<User> GetAllUsers();
    User? GetUserById(int id);
    User? GetUserByEmail(string email);
    bool AddUser(User user);
    bool USerExist(string email);
}