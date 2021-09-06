using Microsoft.AspNetCore.Mvc;
using ReadingIsGood.Business.Abstract;
using ReadingIsGood.Entitties.DTOs;

namespace ReadingIsGood.WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class OperationClaimController : ControllerBase
    {
        private readonly IOperationClaimService _operationClaimService;

        public OperationClaimController(IOperationClaimService operationClaimService)
        {
            _operationClaimService = operationClaimService;
        }

        [HttpPost("add")]

        public IActionResult Add(AddOperationClaimDto addOperationClaimDto)
        {
            var result = _operationClaimService.Add(addOperationClaimDto);
            if (!result.Success)
                return BadRequest(result);
            return Ok(result);
        }
    }
}
