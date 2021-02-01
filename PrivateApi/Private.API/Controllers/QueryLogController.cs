using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Private.Domain.Interfaces.Services;

namespace Private.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class QueryLogController : ControllerBase
    {
        private readonly IQueryLogService _service;

        public QueryLogController(IQueryLogService service)
        {
            _service = service;
        }

        [HttpGet] 
        public async Task<ActionResult> GetAllByFilters([FromQuery] string listType, string initialDate, string endDate, Int64? idProduct, string productDescription)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            //Pegar o id do parceiro ou do cliente diretamente do token
            Int64? idPartner = null;
            Int64? idCustomer = 22;

            if (idCustomer == null && idPartner == null)
            {
                return BadRequest("O identificador do cliente ou do parceiro deve ser passado");
            }

            try
            {
                return Ok(await _service.GetAllByFilters(listType, initialDate, endDate, idCustomer, idPartner, idProduct, productDescription));
            }
            catch (ArgumentException ex)
            {
                return StatusCode((int)HttpStatusCode.InternalServerError, ex.Message);
            }
        }
    }
}