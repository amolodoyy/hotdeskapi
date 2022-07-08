using HotDeskSystemApi.Data.Entities;

namespace HotDeskSystemApi.Data.Repositories
{
    public interface IUserRepository
    {
        public User? GetUser(string username, string password, string role);
    }
}
