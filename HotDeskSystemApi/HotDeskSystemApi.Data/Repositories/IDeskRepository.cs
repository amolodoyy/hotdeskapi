using HotDeskSystemApi.Data.Entities;
using System.Net;

namespace HotDeskSystemApi.Data.Repositories
{
    public interface IDeskRepository
    {
        public List<Desk>? GetDesksByLocation(int userId, int locationId);
        public List<Desk>? GetAvailableDesksAtDate(DateTime date);
        public List<Desk>? GetUnAvailableDesksAtDate(DateTime date);
        public (Desk?, HttpStatusCode) CreateNewDesk(Desk desk, int userId);
        public HttpStatusCode DeleteDesk(int deskId, int userId);
    }
}
