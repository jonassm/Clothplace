using Core;
namespace Backend.Repositories.Interfaces;

public interface IBrugerRepo
{
    public User getUserById(int id);
    // public string GetPasswordByName(string name);
}