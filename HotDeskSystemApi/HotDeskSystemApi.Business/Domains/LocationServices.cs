using HotDeskSystemApi.Business.ViewModels;
using HotDeskSystemApi.Data;
using AutoMapper;
using System.Collections.Generic;
using Microsoft.Extensions.Configuration;
using System.Net;

namespace HotDeskSystemApi.Business.Domains
{
    public class LocationServices : ILocationServices
    {
        private readonly Data.Repositories.LocationRepository repository;
        private readonly IMapper mapper;

        public LocationServices(IConfiguration configuration)
        {
            repository = new Data.Repositories.LocationRepository(configuration);
            mapper = new MapperConfiguration(config =>
            {
                config.CreateMap<Data.Entities.Location, LocationModel>().ReverseMap();
            }).CreateMapper();
        }
        public (LocationModel?, HttpStatusCode) CreateNewLocation(LocationModel locationModel, int userId)
        {
            HttpStatusCode response;
            var entityLocation = mapper.Map<LocationModel, Data.Entities.Location>(locationModel);
            (_, response) = repository.CreateNewLocation(entityLocation, userId);
            return (locationModel, response);
        }
        public HttpStatusCode DeleteLocation(int locationId, int userId)
        {
            return repository.DeleteLocation(locationId, userId);
        }
    }
}
