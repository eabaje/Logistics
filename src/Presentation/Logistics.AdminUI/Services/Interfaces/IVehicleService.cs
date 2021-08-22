using Logistics.Shared.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Logistics.AdminUI.Services.Interfaces
{
    public interface IVehicleService
    {

        public Task<IEnumerable<CustomerDTO>> GetCustomers();
        public Task<CustomerDTO> GetCustomerById(string Id);
        public Task<IEnumerable<CustomerDTO>> GetCustomersByDate(string fromdDateRange, string toDateRange);

        public Task<SuccessModel> AddCustomer(CustomerDTO bookingDTO);

        public Task<SuccessModel> UpdateCustomer(CustomerDTO bookingDTO);

       

        public Task Delete(string Id);
    }
}
