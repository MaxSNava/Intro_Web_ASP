using Microsoft.AspNetCore.Mvc;

namespace Intro_Web_ASP.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class OperationController : ControllerBase
    {
        // GET: api/operation/add?a=10&b=5
        [HttpGet("add")]
        public ActionResult<decimal> Add([FromQuery] decimal a, [FromQuery] decimal b)
        {
            return Ok(a + b);
        }

        // GET: api/operation/header
        [HttpGet("header")]
        public ActionResult<string> ReadHeader([FromHeader(Name = "x-some")] string? customHeader)
        {
            if (string.IsNullOrWhiteSpace(customHeader))
                return BadRequest("El header 'x-some' es requerido.");

            return Ok($"El valor de x-some es: {customHeader}");
        }

        // POST: api/operation
        [HttpPost]
        public ActionResult<decimal> Multiply([FromBody] OperationRequest request)
        {
            return Ok(request.A * request.B);
        }

        // PUT: api/operation
        [HttpPut]
        public ActionResult<decimal> Subtract([FromBody] OperationRequest request)
        {
            return Ok(request.A - request.B);
        }

        // DELETE: api/operation?a=10&b=5
        [HttpDelete]
        public ActionResult<decimal> Divide([FromQuery] decimal a, [FromQuery] decimal b)
        {
            if (b == 0)
                return BadRequest("No se puede dividir entre cero.");

            return Ok(a / b);
        }
    }

    public class OperationRequest
    {
        public decimal A { get; set; }
        public decimal B { get; set; }
    }
}
