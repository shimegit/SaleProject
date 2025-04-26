using AutoMapper;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Orders.BL;
using SaleServer.DTO;
using SaleServer.Migrations;
using SaleServer.Models;

namespace WebApplication1.Controllers
{
   
    [Route("api/[controller]")]
    [ApiController]
    public class GiftsController : ControllerBase
    {
        private readonly Igifts _igifts;
        private readonly IMapper _mapper;

        public GiftsController(Igifts igifts, IMapper mapper)
        {
            this._igifts=igifts??  throw new ArgumentNullException(nameof(igifts));
            _mapper = mapper;
        }

        [HttpGet]
        public async Task<ActionResult<List<Gifts>>> Get()
        {

            return await _igifts.GetGifts();
        }


        [HttpDelete("{id}")]
        [Authorize(Roles = "admin")]
        public async Task Delete(int id)
        {
            _igifts.DeletGift(id);

        }
        [HttpPost]
        [Authorize(Roles = "admin")]
        public async Task Post([FromBody] GiftDTO g)
        {
            var gift = _mapper.Map<Gifts>(g);
            _igifts.AddGift(gift);
        }
        [HttpPut]
        [Authorize(Roles = "admin")]
        [Route("UpdateGift")]
        public async Task Put(GiftDTO g)
        {

            var gift = _mapper.Map<Gifts>(g);
            _igifts.UpdateGift(gift);
        }
        [HttpGet("FindByName")]
        public async Task<ActionResult<List<Gifts>>> FindName(string g)
        {
          return await _igifts.FindName(g);

        }
        [HttpGet("FindByCategory")]
        public async Task<ActionResult<List<Gifts>>> Findcategory(string category)
        {
            return await _igifts.Findcategory(category);

        }
            [HttpGet("FindByDonorName")]
            public async Task<ActionResult<List<Gifts>>> FindByDonorName(string donorName)
            {
                return await _igifts.FindByDonorName(donorName);

            }
        [HttpGet("GetAllGiftIdsFromOrders")]
        public async Task<List<int>> GetAllGiftIdsFromOrders()
        {
            return await _igifts.GetAllGiftIdsFromOrders();
        }

    }
}
