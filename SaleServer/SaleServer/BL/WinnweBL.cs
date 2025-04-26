using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Orders.Dal;
using SaleServer.BL;
using SaleServer.DAL;
using SaleServer.DTO;
using SaleServer.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace SaleServer.DAL
{
    public class WinnerBl : IWinnerBl
    {
        private readonly IWinnerDal _winnerDAL;
        private readonly IgiftsDal _giftdal;
        private readonly IorderDal _orderdal;
        static Random rnd = new Random();

        public WinnerBl(IWinnerDal winnerDAL,IgiftsDal giftdal, IorderDal orderdal)
        {
            this._winnerDAL = winnerDAL ?? throw new ArgumentNullException(nameof(_winnerDAL));
            this._giftdal = giftdal ?? throw new ArgumentNullException(nameof(_giftdal));
            this._orderdal = orderdal ?? throw new ArgumentNullException(nameof(_orderdal));
        }

        public async Task<bool> PerformLottery()
          
        {
            List<int> gifts = await _giftdal.GetAllGiftIdsFromOrders();
            foreach (int gift in gifts)
            {
                List<User> users = await _orderdal.GetGiftBayers(gift);
                var win = rnd.Next(users.Count);
                User winner = users[win];

                _winnerDAL.saveWinning(winner.UserId, gift);
            }
            if (rnd != null)
            {
                return true;
            }

            return false;
        }

        public async Task<List<Winner>> GetWinners()
        {
            return await _winnerDAL.GetWinners();
        }
        public async Task<List<Dictionary<string, List<string>>>> GenerateWinnerReport()
        {
            return await _winnerDAL.GenerateWinnerReport();
        }

    }
}