﻿using Exercicio.Services;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace Exercicio.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class EquipamentosController : ControllerBase
    {

        private readonly ILogger _logger;

        
        // GET: api/<EquipamentosController>
        [HttpGet]
        public string Get()
        {
            try
            {
                EquipDatabase equipDb = new EquipDatabase();

                var result = equipDb.GetAllEquipsNames();

                string jsonTable = JsonConvert.SerializeObject(result);

                return jsonTable;
            }catch(Exception ex)
            {
                _logger.LogError("Erro ao executar o método Get de Equipamentos Controller", ex);
                return ex.Message;
            }
        }

        // POST api/<EquipamentosController>
        [HttpPost]
        public async Task<IActionResult> Post([FromBody] Equipamentos equip)
        {
            try
            {
                EquipDatabase equipDb = new EquipDatabase();
                await equipDb.CreateEquipTable();
                await equipDb.InsertEquipData(equip);
                return Ok();
            }
            catch(Exception ex)
            {
                _logger.LogError("Erro ao executar o método Post de Equipamentos Controller", ex);
                return StatusCode(StatusCodes.Status500InternalServerError);
            }


        }
    }
}
