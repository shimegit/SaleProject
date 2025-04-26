using Microsoft.AspNetCore.Mvc;
using Orders.BL;
using Orders.Dal;
using SaleServer.Models;


using Microsoft.AspNetCore.Mvc;

[Route("api/[controller]")]
[ApiController]
public class WinnerController : ControllerBase
{
    private readonly IWinnerBl _IWinnerBl;

    public WinnerController(IWinnerBl _IWinnerBl)
    {
        this._IWinnerBl = _IWinnerBl?? throw new ArgumentNullException(nameof(_IWinnerBl)); ;
    }


    [HttpGet("Raffle")]
    public async Task<bool> PerformLottery( )
    {
        return await _IWinnerBl.PerformLottery();
    }

    [HttpGet("GetWinners")]

    public async Task<List<Winner>> GetWinners()
    {
        return await _IWinnerBl.GetWinners();
    }
    [HttpGet("GetReport")]

    public async Task<List<Dictionary<string, List<string>>>> GenerateWinnerReport()
    {
        return await _IWinnerBl.GenerateWinnerReport();
    }
   
}






