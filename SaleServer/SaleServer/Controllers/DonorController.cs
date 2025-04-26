using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Orders.BL;
using SaleServer.Models;
using System.Data;


namespace Orders.Controllers
{
    
    [Route("api/[controller]")]
    [ApiController]
   [Authorize(Roles = "admin")]
    public class DonorController : ControllerBase
    {
        private readonly Idonor _idonorr;

        public DonorController(Idonor idonor)
        {
            this._idonorr=idonor??  throw new ArgumentNullException(nameof(idonor));
        }

        [HttpGet]
        public async Task<ActionResult<List<Donor>>> Get()
        {
            return await _idonorr.GetDonor();
        }


        [HttpDelete("{id}")]
        public async Task Delete(int id)
        {
            _idonorr.DeletDonor(id);

        }
        [HttpPost]
        public async Task Post([FromBody] Donor g)
        {
            _idonorr.AddDonor(g);
        }
        [HttpPut]
        [Route("UpdateDonor")]
        public async Task Put(Donor g)
        {
            _idonorr.UpdateDonor(g);
        }
        [HttpGet]
        [Route("FindByName")]
        public async Task<ActionResult<List<Donor>>> FindByName(string g)
        {
            return await _idonorr.FindByName(g);

        }
        [HttpGet]
        [Route("FindByMail")]
        public async Task<ActionResult<List<Donor>>> FindByMail(string g)
        {
            return await _idonorr.FindByMail(g);

        }
        [HttpGet]
        [Route("FindByGift")]
        public async Task<ActionResult<List<Donor>>> FindByGift(string g)
        {
            return await _idonorr.FindByGift(g);

        }
    }
}