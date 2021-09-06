using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using ReadingIsGood.Business.Abstract;
using ReadingIsGood.Core.Extensions;
using ReadingIsGood.Entities.DTOs;
using System.Security.Claims;

namespace ReadingIsGood.WebAPI.Controllers
{
    [Authorize]
    [Route("api/[controller]")]
    [ApiController]
    public class OrderController : ControllerBase
    {
        private readonly IOrderService _orderService;

        public OrderController(IOrderService orderService)
        {
            _orderService = orderService;
        }

        [HttpPost("add")]

        public IActionResult AddOrder(AddOrderDto addOrderDto)
        {
            var result = _orderService.Add(addOrderDto);
            if (!result.Success)
                return BadRequest(result);
            return Ok(result);
        }

        [HttpGet]
        public IActionResult GetAllOrders()
        {
            var result = _orderService.GetAll(HttpContext.User.Claims(ClaimTypes.NameIdentifier)[0]);
            if (!result.Success)
                return BadRequest(result);
            return Ok(result);
           
        }


        [HttpGet("{orderNo}")]
        public IActionResult Get(string orderNo)
        {
            var result = _orderService.Get(orderNo,HttpContext.User.Claims(ClaimTypes.NameIdentifier)[0]);
            if (!result.Success)
                return BadRequest(result);
            return Ok(result);

        }
    }
}
