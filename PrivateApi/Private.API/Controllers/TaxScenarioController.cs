﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Private.Domain.DTOs.TaxScenario;
using Private.Domain.Interfaces.Services;

namespace Private.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TaxScenarioController : ControllerBase
    {
        private readonly ITaxScenarioService _service;

        public TaxScenarioController(ITaxScenarioService service)
        {
            _service = service;
        }

        [HttpGet]
        public async Task<ActionResult> GetAll()
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            try
            {
                return Ok(await _service.GetAll());
            }
            catch (ArgumentException ex)
            {
                return StatusCode((int)HttpStatusCode.InternalServerError, ex.Message);
            }
        }

        [HttpGet("{id}")]
        public async Task<ActionResult> Get(Int64 id)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            try
            {
                return Ok(await _service.Get(id));
            }
            catch (ArgumentException ex)
            {
                return StatusCode((int)HttpStatusCode.InternalServerError, ex.Message);
            }
        }

        [HttpPost]
        public async Task<ActionResult> Post([FromBody] TaxScenarioDtoInsert taxScenario)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            try
            {
                //TODO: pegar o id do usuário no token
                var idUser = 1;

                return Ok(await _service.Post(taxScenario, idUser));
            }
            catch (ArgumentException ex)
            {
                return StatusCode((int)HttpStatusCode.InternalServerError, ex.Message);
            }
        }

        [HttpPut("{id}")]
        public async Task<ActionResult> Put(Int64 id, [FromBody] TaxScenarioDtoUpdate taxScenario)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            try
            {
                //TODO: pegar o id do usuário no token
                var idUser = 1;

                return Ok(await _service.Put(id, taxScenario, idUser));
            }
            catch (ArgumentException ex)
            {
                return StatusCode((int)HttpStatusCode.InternalServerError, ex.Message);
            }
        }
    }
}