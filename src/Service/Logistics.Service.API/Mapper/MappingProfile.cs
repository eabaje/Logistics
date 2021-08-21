using AutoMapper;
using Logistics.Service.API.Entities;
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
            CreateMap<BarberDTO, Barber>();
            CreateMap<BeautySalon, BeautySalonDTO>().ReverseMap();

            CreateMap<ServiceType, ServiceTypeDTO>().ReverseMap(); 

            CreateMap<Payment, PaymentDTO>();

            CreateMap<PriceList, PriceListDTO>().ReverseMap();
            CreateMap<Customer, CustomerDTO>().ReverseMap();

            CreateMap<OrderItem, OrderItemDTO>().ReverseMap();

            //  CreateMap<Favorite, FavoriteDTO>();

            CreateMap<Rating, RateDTO>().ReverseMap();

            //  CreateMap<Calendar, CalendarDTO>();
            CreateMap<Booking, BookingDTO>();
            CreateMap<Barber, BarberDTO>().ReverseMap();

            CreateMap<BookingDTO, Booking>().ForMember(dest => dest.BookDate, opts => opts.MapFrom(src => DateTime.Parse(src.BookDate)));
            CreateMap<Appointment, AppointmentDTO>().ReverseMap();

          //  CreateMap<RoomOrderDetails, RoomOrderDetailsDTO>().ForMember(x => x.HotelRoomDTO, opt => opt.MapFrom(c => c.HotelRoom));
           

        }
    }


  
}
