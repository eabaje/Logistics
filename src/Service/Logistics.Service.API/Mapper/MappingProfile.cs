using AutoMapper;
using Logistics.Service.API.Entities;
using Logistics.Shared.Enumerations;
using Logistics.Shared.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Logistics.Service.API.Mapper
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            CreateMap<Broker, BrokerDTO>();

            CreateMap<Carrier, CarrierDTO>();
            CreateMap<Vehicle, VehicleDTO>();
            CreateMap<Company, CompanyDTO>().ReverseMap();

        //    CreateMap<ServiceType, ServiceTypeDTO>().ReverseMap(); 

            CreateMap<Payment, PaymentDTO>();

            CreateMap<Shipper, ShipperDTO>().ReverseMap();
            CreateMap<Carrier, CarrierDTO>().ReverseMap();

            CreateMap<Broker, BrokerDTO>().ReverseMap();

            //  CreateMap<Favorite, FavoriteDTO>();

            //CreateMap<Rating, RateDTO>().ReverseMap();

            //  CreateMap<Calendar, CalendarDTO>();
            CreateMap<Insurance, InsuranceDTO>().ReverseMap();
            CreateMap<VehicleDriver, DriverDTO>().ReverseMap();

            //CreateMap<BookingDTO, Booking>().ForMember(dest => dest.BookDate, opts => opts.MapFrom(src => DateTime.Parse(src.BookDate)));
            //CreateMap<Appointment, AppointmentDTO>().ReverseMap();

          //  CreateMap<RoomOrderDetails, RoomOrderDetailsDTO>().ForMember(x => x.HotelRoomDTO, opt => opt.MapFrom(c => c.HotelRoom));
           

        }
    }


  
}
