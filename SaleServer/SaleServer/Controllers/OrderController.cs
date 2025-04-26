using AutoMapper;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Orders.BL;
using SaleServer.BL;
using SaleServer.DAL;
using SaleServer.DTO;
using SaleServer.Models;

namespace SaleServer.Controllers
{
    [Authorize]
    [Route("api/[controller]")]
    [ApiController]
    public class OrderController : ControllerBase
    {


        private readonly IorderBL _iorderBL;
        private readonly IMapper _mapper;

        public OrderController(IorderBL iorderBL, IMapper mapper)
        {
            this._iorderBL = iorderBL ?? throw new ArgumentNullException(nameof(IorderBL));
            this._mapper = mapper;
        }
       
        [HttpPost("AddToBasket")]

        public async Task<decimal> AddToBasket(int giftId)
        {

            User user = (User)(HttpContext.Request.HttpContext.Items["User"]);
            await _iorderBL.AddToBasket(user.UserId, giftId, 1);

            return 0;
        }
        [HttpDelete("DeletItemFromBusket")]
        public void RemoveFromBasket(int giftId)
        {
            User user = (User)(HttpContext.Request.HttpContext.Items["User"]);
            
            _iorderBL.RemoveFromBasket(user.UserId,giftId);
        }
        [HttpPost("Payment")]
       public async Task<decimal> PayingForOrder() 
        {
            User user = (User)(HttpContext.Request.HttpContext.Items["User"]);
            await _iorderBL.ProcessPaymentAndCreateOrder(user.UserId);
            return 0;
        }
        [Authorize(Roles = "admin")]
        [HttpGet("SortByHigestPrice")]
        public async Task<Gifts> SortByHigestPrice()
        {
            return await _iorderBL.SortByHigestPrice();
        }
        [Authorize(Roles = "admin")]
        [HttpGet("GetMostParchased")]
        public async Task<Gifts> MostParchased()
        {
            return await _iorderBL.MostParchased();
        }
        [Authorize(Roles = "admin")]
        [HttpGet("GetGiftBayers")]
        public async Task<List<User>> GetGiftBayers(int giftId)
        {
            return await _iorderBL.GetGiftBayers(giftId);
        }
        [Authorize(Roles = "admin")]
        [HttpGet("GetBayersDetails")]
        public async Task<List<User>> GetBayersDetails()
        {
            return await _iorderBL.GetBayersDetails();

        }
        [HttpGet("ShowMyCart1")]

        public async Task<List<Cart>> ShowMyCart1()
        {
            User user = (User)(HttpContext.Request.HttpContext.Items["User"]);
            return await _iorderBL.ShowMyCart1(user.UserId);
        }
        [HttpPost("RemoveQuantityFromBasket")]
        public void RemoveQuantityFromBasket(int giftId)
        {
            User user = (User)(HttpContext.Request.HttpContext.Items["User"]);
            _iorderBL.RemoveQuantityFromBasket(user.UserId, giftId, 1);

        }
        [HttpGet("sumForPaying")]

        public decimal SumForPaying()
        {
            User user = (User)(HttpContext.Request.HttpContext.Items["User"]);
            return  _iorderBL.SumForPaying(user.UserId);
        }
        [Authorize(Roles = "admin")]
        [HttpGet("sum")]
        public async Task<decimal> CalculateTotalOrdersAmount()
        {
            return await _iorderBL.CalculateTotalOrdersAmount();
        }
    }    
}