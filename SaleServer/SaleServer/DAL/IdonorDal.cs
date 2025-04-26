using SaleServer.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Orders.Dal
{
    public interface IdonorDal
    {
        Task<List<Donor>> GetAsync();
        Task DeletDonor(int DonorId);
        Task AddDonor(Donor Donor);
        Task UpdateDonor(Donor Donor);

        Task<List<Donor>> FindByName(string name);
        Task<List<Donor>> FindByMail(string mail);
        Task<List<Donor>> FindByGift(string name);
        

    }
}