using HotDeskSystemApi.Business.ViewModels;

namespace HotDeskSystemApi.Business.Domains
{
    public interface IUserServices
    {
        public UserModel? GetUser(string username, string password, string role);
    }
}
