using AssetManagement.Data.Interfaces;
using AssetManagement.Models;

namespace AssetManagement.Data
{
    public class UserRepository : IUserRepository
    {
        private AssetDbContext _dbContext;

        public UserRepository()
        {
            _dbContext = new AssetDbContext();
        }

        public List<User> GetAllUsers()
        {
            return _dbContext.Users.ToList();
        }


        public void CreateUser(User user)
        {
            _dbContext.Users.Add(user);
            _dbContext.SaveChanges();
           
        }


    }
}
