using AssetManagement.Models;


namespace AssetManagement.Data.Interfaces

{
    public interface IUserRepository
    {
        void CreateUser(User user);
        List<User> GetAllUsers();

    }
}
