using Microsoft.AspNetCore.Mvc;
using SaleServer.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Orders.Dal
{
    public interface IWinnerDal
    {
        public Task<List<User>> GetUsersAsync(int giftId);
        public void saveWinning(int giftID, int userID);
        public Task<List<Winner>> GetWinners();
        public Task<List<Dictionary<string, List<string>>>> GenerateWinnerReport();
    }
}