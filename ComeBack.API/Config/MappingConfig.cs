using AutoMapper;
using ComeBack.API.DAO;
using ComeBack.API.Models;

namespace ComeBack.API.Config
{
    public class MappingConfig
    {
        public static MapperConfiguration RegisterMaps()
        {
            var mappingConfig = new MapperConfiguration(config =>
            {
                config.CreateMap<User, UserDAO>();
                config.CreateMap<UserDAO, User>();
                config.CreateMap<LoginDAO, User>();
                config.CreateMap<User, LoginDAO>();



            });
            return mappingConfig;
        }
    }
}
