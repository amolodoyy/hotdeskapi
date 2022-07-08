using AutoMapper;
using HotDeskSystemApi.Business.ViewModels;
using Microsoft.Extensions.Configuration;

namespace HotDeskSystemApi.Business.Domains
{
    public class UserServices : IUserServices
    {
        private readonly Data.Repositories.UserRepository repository;
        private readonly IMapper mapper;

        public UserServices(IConfiguration configuration)
        {
            repository = new Data.Repositories.UserRepository(configuration);
            mapper = new MapperConfiguration(config =>
            {
                config.CreateMap<Data.Entities.User, UserModel>().ReverseMap();
            }).CreateMapper();
        }
        public UserModel? GetUser(string username, string password, string role)
        {
            var userEntity = repository.GetUser(username, password, role);
            if (userEntity == null) return null;
            return mapper.Map<Data.Entities.User, UserModel>(userEntity);
        }
    }
}
