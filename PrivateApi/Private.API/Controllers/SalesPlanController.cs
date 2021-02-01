using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Private.Domain.DTOs.SalesPlan;
using Private.Domain.Interfaces.Services;

namespace Private.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class SalesPlanController : ControllerBase
    {
        private readonly ISalesPlanService _service;

        public SalesPlanController(ISalesPlanService service)
        {
            _service = service;
        }

        [HttpGet("billing-attribute")]
        public async Task<ActionResult> GetAllBillingAttributeByFilters([FromQuery] string attribute, string value)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            try
            {
                return Ok(await _service.GetAllBillingAttributeByFilters(attribute, value));
            }
            catch (ArgumentException ex)
            {
                return StatusCode((int)HttpStatusCode.InternalServerError, ex.Message);
            }
        }

        [HttpPost("billing-attribute")]
        public async Task<ActionResult> PostBillingAttribute([FromBody] BillingAttributeDtoInsert salesPlan)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            try
            {
                //TODO: pegar o id do usuário no token
                var idUser = 1;

                var result = await _service.PostBillingAttribute(salesPlan, idUser);

                if (result == null)
                    return BadRequest("Já existe um registro com este atributo");

                return Ok(result);
            }
            catch (ArgumentException ex)
            {
                return StatusCode((int)HttpStatusCode.InternalServerError, ex.Message);
            }
        }

        [HttpPut("billing-attribute/{id}")]
        public async Task<ActionResult> PutBillingAttribute(Int64 id, [FromBody] BillingAttributeDtoUpdate salesPlan)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            try
            {
                //TODO: pegar o id do usuário no token
                var idUser = 1;

                if (!String.IsNullOrEmpty(salesPlan.Attribute))
                {
                    var salesPlantDto = await _service.GetBillingAttributeByAttribute(salesPlan.Attribute);

                    if (salesPlantDto != null && salesPlantDto.Id != id)
                        return BadRequest("Este atributo de cobrança já existe");
                }

                return Ok(await _service.PutBillingAttribute(id, salesPlan, idUser));
            }
            catch (ArgumentException ex)
            {
                return StatusCode((int)HttpStatusCode.InternalServerError, ex.Message);
            }
        }

        [HttpDelete("billing-attribute/{id}")]
        public async Task<ActionResult> DeleteBillingAttribute(Int64 id)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            try
            {
                //TODO: pegar o id do usuário no token
                var idUser = 1;

                var result = await _service.DeleteBillingAttribute(id, idUser);

                if (result == null)
                    return BadRequest("O atributo de cobrança não existe");

                return Ok();
            }
            catch (ArgumentException ex)
            {
                return StatusCode((int)HttpStatusCode.InternalServerError, ex.Message);
            }
        }

        [HttpGet("billing-plan")]
        public async Task<ActionResult> GetAllBillingPlansByFilters([FromQuery] string code, string description, string startOfTerm, string endOfTerm, string billingCycle)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            try
            {
                return Ok(await _service.GetAllBillingPlansByFilters(code, description, startOfTerm, endOfTerm, billingCycle));
            }
            catch (ArgumentException ex)
            {
                return StatusCode((int)HttpStatusCode.InternalServerError, ex.Message);
            }
        }

        [HttpPost("billing-plan")]
        public async Task<ActionResult> PostBillingPlan([FromBody] BillingPlanDtoInsert billingPlan)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            try
            {
                //TODO: pegar o id do usuário no token
                var idUser = 1;

                var result = await _service.PostBillingPlan(billingPlan, idUser);

                if (result == null)
                    return BadRequest("Já existe um plano com este código");

                return Ok(result);
            }
            catch (ArgumentException ex)
            {
                return StatusCode((int)HttpStatusCode.InternalServerError, ex.Message);
            }
        }

        [HttpPut("billing-plan/{id}")]
        public async Task<ActionResult> PutBillingPlan(Int64 id, [FromBody] BillingPlanDtoUpdate billingPlan)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            try
            {
                //TODO: pegar o id do usuário no token
                var idUser = 1;

                return Ok(await _service.PutBillingPlan(id, billingPlan, idUser));
            }
            catch (ArgumentException ex)
            {
                return StatusCode((int)HttpStatusCode.InternalServerError, ex.Message);
            }
        }

        [HttpDelete("billing-plan/{id}")]
        public async Task<ActionResult> DeleteBillingPlan(Int64 id)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            try
            {
                //TODO: pegar o id do usuário no token
                var idUser = 1;

                var result = await _service.DeleteBillingPlan(id, idUser);

                if (result == null)
                    return BadRequest("O plano de cobrança não existe");

                return Ok();
            }
            catch (ArgumentException ex)
            {
                return StatusCode((int)HttpStatusCode.InternalServerError, ex.Message);
            }
        }

        [HttpPost("plan-attribute/{id}/attr")]
        public async Task<ActionResult> PostPlanAttribute(Int64 id, [FromBody] PlanAttributeDtoInsert planAttribute)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            try
            {
                //TODO: pegar o id do usuário no token
                var idUser = 1;

                var billingAttributeDto = await _service.GetBillingAttributeById(planAttribute.IdBillingAttribute);

                if (billingAttributeDto == null)
                    return BadRequest("Este atributo de cobrança não existe");                

                var result = await _service.PostPlanAttribute(id, planAttribute, idUser);

                if (result == null)
                    return BadRequest("Este plano de cobrança não existe");

                return Ok(result);
            }
            catch (ArgumentException ex)
            {
                return StatusCode((int)HttpStatusCode.InternalServerError, ex.Message);
            }
        }

        [HttpPut("plan-attribute/{id}/attr/{idAttr}")]
        public async Task<ActionResult> PutPlanAttribute(Int64 id, Int64 idAttr, [FromBody] PlanAttributeDtoUpdate planAttribute)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            try
            {
                //TODO: pegar o id do usuário no token
                var idUser = 1;

                var result = await _service.PutPlanAttribute(id, idAttr, planAttribute, idUser);

                if (result == null)
                    return BadRequest("Este plano de cobrança ou o atributo de cobrança não existe");

                return Ok(result);
            }
            catch (ArgumentException ex)
            {
                return StatusCode((int)HttpStatusCode.InternalServerError, ex.Message);
            }
        }
    }
}