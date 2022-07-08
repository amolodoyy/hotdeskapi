using AutoMapper;
using HotDeskSystemApi.Business.ViewModels;
using System.Net;
using Microsoft.Extensions.Configuration;


namespace HotDeskSystemApi.Business.Domains
{
    public class ReservationServices : IReservationServices
    {
        private readonly Data.Repositories.ReservationRepository repository;
        private readonly IMapper mapper;

        public ReservationServices(IConfiguration configuration)
        {
            repository = new Data.Repositories.ReservationRepository(configuration);
            mapper = new MapperConfiguration(config =>
            {
                config.CreateMap<Data.Entities.Reservation, ReservationModel>().ReverseMap();
            }).CreateMapper();
        }
        public (ReservationModel?, HttpStatusCode) CreateReservation(ReservationModel reservationModel)
        {
            HttpStatusCode response;
            var reservationEntity = mapper.Map<ReservationModel, Data.Entities.Reservation>(reservationModel);
            (_, response) = repository.CreateReservation(reservationEntity);
            return (reservationModel, response);
        }

        public (ReservationModel?, HttpStatusCode) EditReservation(ReservationModel reservationModel)
        {
            HttpStatusCode response;
            var reservationEntity = mapper.Map<ReservationModel, Data.Entities.Reservation>(reservationModel);
            (_, response) = repository.EditReservation(reservationEntity);
            return (reservationModel, response);
        }

        public List<ReservationModel>? GetReservationsByLocation(int locationId)
        {
            var reservationsEntity = repository.GetReservationsByLocation(locationId);
            
            if(reservationsEntity == null) return null;

            List<ReservationModel>? result = new();
            foreach (var r in reservationsEntity)
                result.Add(mapper.Map<Data.Entities.Reservation, ReservationModel>(r));
            return result;
        }
    }
}
