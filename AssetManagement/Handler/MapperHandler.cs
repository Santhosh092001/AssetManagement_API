using AssetManagement.Models;
using AutoMapper;

namespace AssetManagement.Handler
{
    public class MapperHandler : Profile
    {
        public MapperHandler()
        {
            CreateMap<User, User>();
        }
    }
}
