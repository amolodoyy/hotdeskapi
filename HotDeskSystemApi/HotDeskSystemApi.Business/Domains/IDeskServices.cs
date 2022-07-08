using HotDeskSystemApi.Business.ViewModels;
using System.Net;

namespace HotDeskSystemApi.Business.Domains
{
    public interface IDeskServices
    {
        public List<DeskModel>? GetDesksByLocation(int userId, int locationId);
        public List<DeskModel>? GetAvailableDesksAtDate(DateTime date);
        public List<DeskModel>? GetUnAvailableDesksAtDate(DateTime date);
        public (DeskModel?, HttpStatusCode) CreateNewDesk(DeskModel deskModel, int userId);
        public HttpStatusCode DeleteDesk(int deskId, int userId);
    }
}
