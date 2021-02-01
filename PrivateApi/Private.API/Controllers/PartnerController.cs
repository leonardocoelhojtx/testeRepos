using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Private.Domain.DTOs.Partner;
using Private.Domain.DTOs.PartnerPlan;
using Private.Domain.DTOs.PersonAddress;
using Private.Domain.Interfaces.Services;

namespace Private.API.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class PartnerController : ControllerBase
    {
        private readonly IPartnerService _service;

        public PartnerController(IPartnerService service)
        {
            _service = service;
        }

        [HttpGet]
        public async Task<ActionResult> Get()
        {
            //TODO: pegar o id do parceiro no token
            Int64 id = 9;

            try
            {
                return Ok(await _service.Get(id));
            }
            catch (ArgumentException ex)
            {
                return StatusCode((int)HttpStatusCode.InternalServerError, ex.Message);
            }

        }

        [HttpGet]
        [Route("GetById/{idPartner}")]
        public async Task<ActionResult> Get(Int64 idPartner)
        {
            try
            {
                return Ok(await _service.Get(idPartner));
            }
            catch (ArgumentException ex)
            {
                return StatusCode((int)HttpStatusCode.InternalServerError, ex.Message);
            }

        }

        [HttpGet]
        [Route("GetByFilters")]
        public async Task<ActionResult> GetByFilters([FromQuery] Int64? id, string reasonName, string fantasy, Int64? cpfCnpj, string status, string filter, string filterType)
        {
            try
            {
                return Ok(await _service.Get(id, reasonName, fantasy, cpfCnpj, status, filter, filterType));
            }
            catch (ArgumentException ex)
            {
                return StatusCode((int)HttpStatusCode.InternalServerError, ex.Message);
            }

        }

        [HttpGet]
        [Route("GetPartnerUsers")]
        public async Task<ActionResult> GetPartnerUsers()
        {
            //TODO: pegar o id do parceiro no token
            Int64 id = 9;

            try
            {
                return Ok(await _service.GetPartnerUsers(id));
            }
            catch (ArgumentException ex)
            {
                return StatusCode((int)HttpStatusCode.InternalServerError, ex.Message);
            }

        }

        [HttpGet]
        [Route("GetPartnerPlan/{idPartner}")]
        public async Task<ActionResult> GetPartnerPlan(Int64 idPartner)
        {
            try
            {
                return Ok(await _service.GetPartnerPlan(idPartner));
            }
            catch (ArgumentException ex)
            {
                return StatusCode((int)HttpStatusCode.InternalServerError, ex.Message);
            }

        }

        [HttpPut]
        public async Task<IActionResult> Update([FromBody] PartnerDtoUpdate partner)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest();
            }

            try
            {

                //TODO: pegar o id do usuário no token
                partner.IdUser = 36;

                await _service.PutPersonAndPartner(partner);

                return Ok(await _service.Get(partner.Id));
            }
            catch (ArgumentException ex)
            {
                return StatusCode((int)HttpStatusCode.InternalServerError, ex.Message);
            }
        }

        [HttpPut]
        [Route("PutPartnerAddress/{idPartner}/{idPersonAddress}")]
        public async Task<IActionResult> UpdatePartnerAddress(Int64 idPartner, Int64 idPersonAddress, [FromBody] PersonAddressDtoUpdate personAddress)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest();
            }

            try
            {
                //TODO: pegar o id do usuário no token
                Int64 idUser = 8;

                var result = await _service.PutPartnerAddress(idPersonAddress, idPartner, idUser, personAddress);

                return Ok(result);
            }
            catch (ArgumentException ex)
            {
                return StatusCode((int)HttpStatusCode.InternalServerError, ex.Message);
            }
        }

        [HttpPut]
        [Route("PutPartnerUserSituation/{idUser}/{situation}")]
        public async Task<IActionResult> UpdatePartnerUserSituation(Int64 idUser, string situation)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest();
            }

            try
            {
                if (String.IsNullOrEmpty(situation))
                    return BadRequest("Situação é um campo obrigatório");

                //TODO: pegar o id do parceiro no token
                Int64 idPartner = 6;

                await _service.PutPartnerUserSituation(idPartner, idUser, situation);

                return Ok();
            }
            catch (ArgumentException ex)
            {
                return StatusCode((int)HttpStatusCode.InternalServerError, ex.Message);
            }
        }

        [HttpPost]
        [Route("PostPartnerUser/{idUser}")]
        public async Task<IActionResult> InsertPartnerUser(Int64 idUser)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest();
            }

            try
            {
                if (idUser <= 0)
                    return BadRequest("Id do usuário inválido");

                //TODO: pegar o id do parceiro no token
                Int64 idPartner = 9;

                //TODO: pegar o id do usuário no token
                Int64 idUserLogged = 36;

                await _service.PostPartnerUser(idPartner, idUser, idUserLogged);

                return Ok();
            }
            catch (ArgumentException ex)
            {
                return StatusCode((int)HttpStatusCode.InternalServerError, ex.Message);
            }
        }

        [HttpPut]
        [Route("{id}/status/{status}")]
        public async Task<IActionResult> UpdateStatusPartnerPerson(Int64 id, string status)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest();
            }

            try
            {
                //TODO: pegar o id do parceiro no token
                Int64 idUserLogged = 6;

                var result = await _service.PutStatusPartnerPerson(id, idUserLogged, status);

                return Ok(result);
            }
            catch (ArgumentException ex)
            {
                return StatusCode((int)HttpStatusCode.InternalServerError, ex.Message);
            }
        }

        [HttpPost]
        public async Task<IActionResult> InsertPartner([FromBody] PartnerDtoInsert partner)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest();
            }

            try
            {
                //TODO: pegar o id do usuário no token
                Int64 idUserLogged = 36;

                var result = await _service.PostPartner(idUserLogged, partner);

                return Ok(result);
            }
            catch (ArgumentException ex)
            {
                return StatusCode((int)HttpStatusCode.InternalServerError, ex.Message);
            }
        }

        [HttpPost]
        [Route("PartnerBillingPlan")]
        public async Task<IActionResult> InsertPartnerBillingPlan([FromBody] PartnerBillingPlanDtoInsert partnerBillingPlanDtoInsert)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest();
            }

            try
            {
                //TODO: pegar o id do usuário no token
                Int64 idUserLogged = 36;

                var result = await _service.PostPartnerBillingPlan(partnerBillingPlanDtoInsert, idUserLogged);

                if (result == null)
                    return BadRequest("Este parceiro já possui o mesmo plano ativado no período de vigência definido");

                return Ok(result);
            }
            catch (ArgumentException ex)
            {
                return StatusCode((int)HttpStatusCode.InternalServerError, ex.Message);
            }
        }

        [HttpPut]
        [Route("PartnerBillingPlan/{idPartnerBillingPlan}/status/{status}")]
        public async Task<IActionResult> UpdateStatusPartnerPlan(Int64 idPartnerBillingPlan, string status)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest();
            }

            try
            {
                //TODO: pegar o id do parceiro no token
                Int64 idUserLogged = 36;

                await _service.PutStatusPartnerBillingPlan(idPartnerBillingPlan, idUserLogged, status);

                return Ok();
            }
            catch (ArgumentException ex)
            {
                return StatusCode((int)HttpStatusCode.InternalServerError, ex.Message);
            }
        }
    }
}