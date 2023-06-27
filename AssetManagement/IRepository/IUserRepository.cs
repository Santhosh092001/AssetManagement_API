using AssetManagement.Dto;
using AssetManagement.Models;

namespace AssetManagement.IRepository
{
    public interface IUserRepository
    {
        public User createUser(User user);
        public bool updateUser(User updateUser);
        public List<User> getUserDetails();
        public List<string> getUserList();
    }
}
