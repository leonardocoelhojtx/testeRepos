using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Private.Domain.DTOs.Report;
using Private.Domain.Interfaces.Services;

namespace Private.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ReportController : ControllerBase
    {
        private readonly IReportService _reportService;

        public ReportController(IReportService reportService)
        {
            _reportService = reportService;
        }

        [HttpGet("laudo/{hash}")]
        public ActionResult GetReport(string hash, string cnpj)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (string.IsNullOrEmpty(cnpj))
                return BadRequest("CNPJ é obrigatório");

            try
            {
                var result = _reportService.GetReport(hash, cnpj);

                if (result == null)
                    return BadRequest("Hash ou CNPJ inválidos");

                return Ok(_reportService.GetReport(hash, cnpj));
            }
            catch (ArgumentException ex)
            {
                return StatusCode((int)HttpStatusCode.InternalServerError, ex.Message);
            }
        }
    }
}
