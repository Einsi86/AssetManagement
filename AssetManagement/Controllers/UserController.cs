using AssetManagement.Data.Interfaces;
using AssetManagement.Models.DTO;
using AssetManagement.Models;
using Microsoft.AspNetCore.Mvc;

namespace AssetManagement.Controllers
{
    public class UserController : ControllerBase
    {
        private IUserRepository _repo;

        public UserController(IUserRepository repo)
        {
            _repo = repo;
        }


        [HttpGet]
        [Route("GetUser")]
        public List<User> GetAllUsers()
        {
            return _repo.GetAllUsers();
        }



        [HttpPost]
        [Route("PostUser")]
        public void CreateUser(string name, string email, string phone, string location)
        {
            User u = new User();
            u.Name = name; u.Email = email; u.Phone = phone; u.Location = location;

            _repo.CreateUser(u);

        }
    }
}
