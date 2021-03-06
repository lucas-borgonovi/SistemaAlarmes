using Exercicio.Models;
using Exercicio.Services;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Threading.Tasks;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace Exercicio.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AlarmesController : ControllerBase
    {

        private readonly ILogger<AlarmesController> _logger;
        private readonly AlarmDatabase _alarmDb;

        public AlarmesController(ILogger<AlarmesController> logger, AlarmDatabase alarmDb)
        {
            _logger = logger;
            _alarmDb = alarmDb;
        }
        

        // GET: api/<ValuesController>
        [HttpGet]
        public string Get()
        {

            try
            {

                var result = _alarmDb.GetAllAlarms();

                string jsonTable = JsonConvert.SerializeObject(result);

                return jsonTable;

            }catch(Exception ex)
            {
                _logger.LogError("Erro ao executar o método Get de Alarmes Controller", ex);
                return ex.Message;
            }
        }

        // POST api/<AlarmesController>
        [HttpPost]
        public async Task<IActionResult> Post([FromBody] Alarmes alarm)
        {
            try
            {

                await _alarmDb.CreateAlarmeTable();
                await _alarmDb.InsertAlarmData(alarm);
                return Ok();

            }catch(Exception ex)
            {
                _logger.LogError("Erro ao executar o método Post de Alarmes Controller",ex);
                return StatusCode(StatusCodes.Status500InternalServerError);
            }
        }

        // PUT api/<AlarmesController>/5
        [HttpPut("{id}")]
        public async Task<IActionResult> Put(int id, [FromBody] Alarmes alarm)
        {
            try
            {
                await _alarmDb.UpdateAlarms(id,alarm);

                return Ok();

            }catch(Exception ex)
            {

                _logger.LogError("Erro ao executar o metodo put de Alarmes Constroller", ex);

                return StatusCode(StatusCodes.Status500InternalServerError);
            }
        }

    }
}
