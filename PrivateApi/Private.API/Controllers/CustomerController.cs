using Microsoft.AspNetCore.Mvc;
using Private.Domain.DTOs.Customer;
using Private.Domain.DTOs.Person;
using Private.Domain.DTOs.PersonAddress;
using Private.Domain.Interfaces.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Threading.Tasks;

namespace Private.API.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class CustomerController : ControllerBase
    {
        private readonly ICustomerService _service;

        public CustomerController(ICustomerService service)
        {
            _service = service;
        }

        [HttpGet]
        public async Task<IActionResult> Get()
        {
            //TODO: pegar o id do cliente no token
            Int64 id = 1;

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
        [Route("GetCustomerUsers")]
        public async Task<ActionResult> GetCustomerUsers()
        {
            //TODO: pegar o id do parceiro no token
            Int64 id = 1;

            try
            {
                return Ok(await _service.GetCustomerUsers(id));
            }
            catch (ArgumentException ex)
            {
                return StatusCode((int)HttpStatusCode.InternalServerError, ex.Message);
            }

        }

        [HttpPut]
        public async Task<IActionResult> Update([FromBody] CustomerDtoUpdate customer)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest();
            }

            try
            {
                //TODO: pegar o id do cliente no token
                customer.Id = 1;
                //TODO: pegar o id do usuário no token
                customer.IdUser = 8;

                await _service.PutPersonAndCustomer(customer);

                return Ok(await _service.Get(customer.Id));
            }
            catch (ArgumentException ex)
            {
                return StatusCode((int)HttpStatusCode.InternalServerError, ex.Message);
            }
        }

        [HttpPut]
        [Route("PutCustomerAddress/{idPersonAddress}")]
        public async Task<IActionResult> UpdateCustomerAddress(Int64 idPersonAddress, [FromBody] PersonAddressDtoUpdate personAddress)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest();
            }

            try
            {
                //TODO: pegar o id do cliente no token
                Int64 idCustomer = 1;
                //TODO: pegar o id do usuário no token
                Int64 idUser = 8;

                var result = await _service.PutPartnerAddress(idPersonAddress, idCustomer, idUser, personAddress);

                return Ok(result);
            }
            catch (ArgumentException ex)
            {
                return StatusCode((int)HttpStatusCode.InternalServerError, ex.Message);
            }
        }

        [HttpPut]
        [Route("PutCustomerUserSituation/{idUser}/{situation}")]
        public async Task<IActionResult> UpdateCustomerUserSituation(Int64 idUser, string situation)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest();
            }

            try
            {
                if (String.IsNullOrEmpty(situation))
                    return BadRequest("Situação é um campo obrigatório");

                //TODO: pegar o id do cliente no token
                Int64 idCustomer = 1;

                await _service.PutCustomerUserSituation(idCustomer, idUser, situation);

                return Ok();
            }
            catch (ArgumentException ex)
            {
                return StatusCode((int)HttpStatusCode.InternalServerError, ex.Message);
            }
        }

        [HttpPost]
        [Route("PostCustomerUser/{idUser}")]
        public async Task<IActionResult> InsertCustomerUser(Int64 idUser)
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
                Int64 idCustomer = 1;

                //TODO: pegar o id do usuário no token
                Int64 idUserLogged = 10;

                await _service.PostCustomerUser(idCustomer, idUser, idUserLogged);

                return Ok();
            }
            catch (ArgumentException ex)
            {
                return StatusCode((int)HttpStatusCode.InternalServerError, ex.Message);
            }
        }
    }
}
