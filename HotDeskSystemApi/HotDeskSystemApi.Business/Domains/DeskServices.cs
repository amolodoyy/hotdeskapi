using AutoMapper;
using HotDeskSystemApi.Business.ViewModels;
using System.Net;
using Microsoft.Extensions.Configuration;

namespace HotDeskSystemApi.Business.Domains
{
    public class DeskServices : IDeskServices
    {
        private readonly Data.Repositories.DeskRepository repository;
        private readonly IMapper mapper;

        public DeskServices(IConfiguration configuration)
        {
            repository = new Data.Repositories.DeskRepository(configuration);
            mapper = new MapperConfiguration(config =>
            {
                config.CreateMap<Data.Entities.Desk, DeskModel>().ReverseMap();
            }).CreateMapper();
        }
        public (DeskModel?, HttpStatusCode) CreateNewDesk(DeskModel deskModel, int userId)
        {
            HttpStatusCode response;
            Data.Entities.Desk deskEntity = mapper.Map<DeskModel, Data.Entities.Desk>(deskModel);

            (_, response) = repository.CreateNewDesk(deskEntity, userId);

            return (deskModel, response);
        }

        public HttpStatusCode DeleteDesk(int deskId, int userId)
        {
            return repository.DeleteDesk(deskId, userId);
        }

        public List<DeskModel>? GetAvailableDesksAtDate(DateTime date)
        {
            var desksEntity = repository.GetAvailableDesksAtDate(date);

            if(desksEntity == null) return null;

            List<DeskModel> result = new List<DeskModel>(desksEntity.Count);
            foreach (var d in desksEntity)
                result.Add(mapper.Map<Data.Entities.Desk, DeskModel>(d));
            return result;
        }

        public List<DeskModel>? GetDesksByLocation(int userId, int locationId)
        {
            var desksEntity = repository.GetDesksByLocation(userId, locationId);

            if (desksEntity == null) return null;

            List<DeskModel> result = new List<DeskModel>(desksEntity.Count);
            foreach (var d in desksEntity)
                result.Add(mapper.Map<Data.Entities.Desk, DeskModel>(d));
            return result;
        }

        public List<DeskModel>? GetUnAvailableDesksAtDate(DateTime date)
        {
            var desksEntity = repository.GetUnAvailableDesksAtDate(date);

            if (desksEntity == null) return null;

            List<DeskModel> result = new List<DeskModel>(desksEntity.Count);
            foreach (var d in desksEntity)
                result.Add(mapper.Map<Data.Entities.Desk, DeskModel>(d));
            return result;
        }
    }
}
