using HotDeskSystemApi.Business.ViewModels;
using System.Net;

namespace HotDeskSystemApi.Business.Domains
{
    public interface ILocationServices
    {
        public (LocationModel?, HttpStatusCode) CreateNewLocation(LocationModel locationModel, int userId);
        public HttpStatusCode DeleteLocation(int locationId, int userId);
    }
}
