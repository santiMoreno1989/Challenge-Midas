using Application.Common.Dtos.Requests;
using Application.Common.Dtos.Responses;
using Application.Common.Interfaces.IServices;
using Microsoft.AspNetCore.Mvc;

namespace WebAPI.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    [Produces("application/json")]
    public class HuespedController : ControllerBase
    {
        private readonly IHuespedService _huespedService;

        public HuespedController(IHuespedService huespedService)
        {
            _huespedService = huespedService;
        }

        [HttpGet("GetAll")]
        public async  Task<IActionResult> GetAllHuespedes()
        {
           var huespedes = await _huespedService.GetAllHuespedesAsync();
            return Ok(huespedes);
        }

        [HttpPost("CreateHuesped")]
        public async Task<IActionResult> CreateNewHuesped(HuespedRequest huespedRequest) 
        {
            var result =  await _huespedService.AddHuesped(huespedRequest);
            return Created("New resource",result);
        }

        [HttpPut("UpdateHuesped")]
        public async Task<IActionResult> UpdateHuesped(int id, HuespedRequest huesped) 
        {
            await _huespedService.UpdateHuesped(id, huesped);
            return Ok();
        }

        [HttpDelete("DeleteHuesped")]
        public async Task<IActionResult> DeleteHuesped(int id) 
        {
            await _huespedService.DeleteHuesped(id);
            return Ok();
        }
    }
}
