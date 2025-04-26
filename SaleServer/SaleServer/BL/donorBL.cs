
using Orders.Dal;
using SaleServer.DAL;
using SaleServer.Models;

namespace Orders.BL
{
    public class donorBL : Idonor
    {
        private readonly IdonorDal _DonorDAL;

        public donorBL(IdonorDal donorDAL)
        {
            this._DonorDAL = donorDAL??  throw new ArgumentNullException(nameof(donorDAL));
        }


        public async Task<List<Donor>> GetDonor()
        {
            return await _DonorDAL.GetAsync();
        }

        public async Task DeletDonor(int DonorId)
        {

            _DonorDAL.DeletDonor(DonorId);

        }
        public async Task AddDonor(Donor g)
        {
            _DonorDAL.AddDonor(g);

        }

        public async Task UpdateDonor(Donor g)
        {
             _DonorDAL.UpdateDonor(g);

        }
        public async Task<List<Donor>> FindByName(string name)
        {
            return await _DonorDAL.FindByName(name);
        }
        public async Task<List<Donor>> FindByMail(string mail)
        {
            return await _DonorDAL.FindByMail(mail);
        }
        public async Task<List<Donor>> FindByGift(string name)

        {
            return await _DonorDAL.FindByGift(name);
        }

    }
}