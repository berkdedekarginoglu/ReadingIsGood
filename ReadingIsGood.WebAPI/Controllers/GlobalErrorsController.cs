using Microsoft.AspNetCore.Mvc;

namespace ReadingIsGood.WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [ApiExplorerSettings(IgnoreApi =true)]
    public class GlobalErrorsController : ControllerBase
    {
        [HttpGet]
        [Route("/errors")]

        public IActionResult HandleErrors()
        {
            return Problem("Something went wrong");
        }
    }
}
