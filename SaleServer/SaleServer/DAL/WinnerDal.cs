using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Orders.Dal;
using SaleServer.BL;
using SaleServer.DAL;
using SaleServer.DTO;
using SaleServer.Models;
using System;
using System.Text;

namespace SaleServer.DAL
{
    public class WinnerDal : IWinnerDal
    {
        private readonly SaleContext _saleContext;

        public WinnerDal(SaleContext saleContext)
        {
            this._saleContext = saleContext ?? throw new ArgumentNullException(nameof(saleContext));
        }

        public async Task<List<User>> GetUsersAsync(int giftId)
        {

            var users = await _saleContext.User
                             .Where(u => u.orders.All(o => o.orderItems.All(oi => oi.Id == giftId)))
                             .Include(u => u.orders)
                            .ThenInclude(o => o.orderItems)
                            .ToListAsync();

            return users;


        }
        public async Task<List<Winner>> GetWinners()
        {
            return await _saleContext.Winner
                  .Include(w => w.User) 
                  .Include(w => w.Gift) 
                  .ToListAsync();

            //}
        }
    
        public async void saveWinning(int userID, int giftID)
        {
            Winner w = new Winner();
            
               w. UserId = userID;
               w. GiftId = giftID;
            
            _saleContext.Winner.AddAsync(w);
             _saleContext.SaveChanges();



        }
        public async Task<List<Dictionary<string, List<string>>>> GenerateWinnerReport()
        {
            List<Winner> winners = await GetWinners();
            List<Dictionary<string, List<string>>> report = new List<Dictionary<string, List<string>>>();

            foreach (Winner winner in winners)
            {
                string giftName = winner.Gift.name;
                string winnerName = winner.User.UserName;

                Dictionary<string, List<string>> reportEntry = report.FirstOrDefault(r => r.ContainsKey(giftName));

                if (reportEntry == null)
                {
                    reportEntry = new Dictionary<string, List<string>>();
                    reportEntry.Add(giftName, new List<string>());
                    report.Add(reportEntry);
                }

                reportEntry[giftName].Add(winnerName);
            }

            return report;
        }


    }
}

    











