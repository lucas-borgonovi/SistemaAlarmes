using Exercicio.Models;
using Microsoft.AspNetCore.Mvc;
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
        

        // GET: api/<ValuesController>
        [HttpGet]
        public string GetAllAlarms()
        {
            var result = Database.GetAllAlarms();

            string jsonTable = JsonConvert.SerializeObject(result);

            return jsonTable;
        }

        // GET api/<AlarmesController>/5
        [HttpGet("{id}")]
        public string Get(int id)
        {
            return "value";
        }

        // POST api/<AlarmesController>
        [HttpPost]
        public async Task<IActionResult> Post([FromBody] Alarmes alarm)
        {
            await Database.CreateAlarmeTable();
            await Database.InsertAlarmData(alarm);
            return Ok();
        }

        // PUT api/<AlarmesController>/5
        [HttpPut("{id}")]
        public async Task<IActionResult> Put(int id, [FromBody] Alarmes alarm)
        {
            await Database.UpdateAlarms(id,alarm);

            return NoContent();
        }

        // DELETE api/<AlarmesController>/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
            
        }
    }
}
