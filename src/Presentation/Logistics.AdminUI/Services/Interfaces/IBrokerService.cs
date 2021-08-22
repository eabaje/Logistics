using Salon.Common;
using Logistics.Shared.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Logistics.AdminUI.Services.Interfaces
{

    public interface IBrokerService
    {

       
            public Task<IEnumerable<BookingDTO>> GetBookings();
            public Task<BookingDTO> GetBookingById(string Id);
            public Task<IEnumerable<BookingDTO>> GetBookingsByDate(string fromdDateRange, string toDateRange);

            public Task<BookingDTO> AddBooking(BookingDTO bookingDTO);

             //  public Task<SuccessModel> AddBooking(BookingDTO bookingDTO);

           public Task<SuccessModel> UpdateBooking(BookingDTO bookingDTO);

            public Task<SuccessModel> UpdateBookingStatus(string BookId,BookStatus bookingDTO);

            public Task Delete(string Id);

    }
}
