using Core;
namespace Backend.Repositories.Interfaces;

public interface IBrugerRepo
{
    public User getUser(int id);

    public User Login(string email);

    public void CreateUser(User user);
    // public string GetPasswordByName(string name);
}