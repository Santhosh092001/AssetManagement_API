using AssetManagement.DBContext;
using AssetManagement.Dto;
using AssetManagement.IRepository;
using AssetManagement.Models;
using AutoMapper;
using Microsoft.AspNetCore.Mvc;

namespace AssetManagement.Repositories
{
    public class UserRepository : IUserRepository
    {
        private readonly AMDbcontext _context;
        private readonly IMapper _mapper;
        public UserRepository(AMDbcontext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        public User createUser(User user)
        {
            var newuser = _context.Users.FirstOrDefault(x => x.UserName == user.UserName);
            if (newuser == null)
            {
                _context.Users.Add(user);
                _context.SaveChanges();
                return user;
            }
            else
            {
                return null;
            }
        }


        public bool updateUser(User updateUser)
        {
            var user = _context.Users.FirstOrDefault(x => x.Id == updateUser.Id);
            if (user != null)
            {
                /*user = _mapper.Map<User>(updateUser);*/
                user.UserName = updateUser.UserName;
                user.FirstName = updateUser.FirstName;
                user.LastName = updateUser.LastName;
                user.Email = updateUser.Email;
                user.Password = updateUser.Password;
                _context.SaveChanges();
                return true;
            }
            else
                return false;
        }

        public List<User> getUserDetails()
        {
            return _context.Users.ToList();
        }


        public List<string> getUserList()
        {
            var list = new List<string>();
            var users = _context.Users.ToList();
            if(users.Count > 0)
            {
                foreach(User user in users)
                {
                    list.Add(user.FirstName + ' ' + user.LastName);
                }
                return list;
            }
            else
            {
                return null;
            }
        }

    }
}
