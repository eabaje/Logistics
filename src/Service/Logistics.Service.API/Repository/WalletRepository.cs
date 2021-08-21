
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using Carrier.Domain.Entities;
using Carrier.FirebaseServer.Interface;
using Carrier.FirebaseServer.Repository;
using Firebase.Database;
using Firebase.Database.Query;
namespace Logistics.Service.API.Repository
{
    public class WalletRepository : FirebaseDataStore<Wallet>, IWalletService
    {

        private IFireBaseAuthService _authservice;
        private readonly IWalletService _WalletRepository;



       
        public WalletRepository(IWalletService WalletRepository, IFireBaseAuthService authService) : base(authService, "Wallets")
        {
            _WalletRepository = WalletRepository;
        }
        public async Task<IEnumerable<Wallet>> GetAllWallet()
        {
            try
            {

                var lst = await _WalletRepository.GetItemsAsync(true);
                return lst;


            }
            catch
            {
                throw;
            }
        }
        public async Task<bool> AddWallet(Wallet Wallet)
        {
            try
            {

                bool done = await _WalletRepository.AddItemAsync(Wallet);
                return done;

            }
            catch
            {
                throw;
            }
        }
        public async Task<bool> UpdateWallet(Wallet Wallet)
        {
            try
            {

                bool done = await _WalletRepository.UpdateItemAsync(Wallet.Uid.ToString(), Wallet);

                return done;
            }
            catch
            {
                throw;
            }
        }
        public async Task<Wallet> GetWalletById(string id)
        {
            try
            {

                var entity = await _WalletRepository.GetItemAsync(id);

                return entity;
            }
            catch
            {
                throw;
            }
        }



        public async Task<IEnumerable<Wallet>> GetWalletByCarrier(string carrierid)
        {
            try
            {
                var lst = await _WalletRepository.GetItemsByCritriaAsync(carrierid);
                return lst;
            }
            catch
            {
                throw;
            }
        }
        public async Task<IEnumerable<Wallet>> GetWalletByShipper(string shipperid)
        {
            try
            {
                var lst = await _WalletRepository.GetItemsByCritriaAsync(shipperid);
                return lst;
            }
            catch
            {
                throw;
            }
        }

        public async Task<IEnumerable<Wallet>> GetWalletByDate(string date)
        {
            try
            {
                var lst = await _WalletRepository.GetItemsByCritriaAsync(date);
                return lst;
            }
            catch
            {
                throw;
            }
        }
        public async Task<bool> DeleteWallet(string id)
        {
            try
            {
                bool done = await _WalletRepository.DeleteItemAsync(id);

                return done;
            }
            catch
            {
                throw;
            }
        }
    }
}
