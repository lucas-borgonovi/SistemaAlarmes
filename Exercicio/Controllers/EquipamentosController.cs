using Microsoft.AspNetCore.Mvc;
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

        
        // GET: api/<AlarmesController>
        [HttpGet]
        public string GetEquipNames()
        {
            var result = Database.GetAllEquipsNames();

            string jsonTable = JsonConvert.SerializeObject(result);

            return jsonTable;
        }

        // GET api/<ValuesController>/5
        [HttpGet("{id}")]
        public string Get(int id)
        {
            return "value";
        }

        // POST api/<ValuesController>
        [HttpPost]
        public async Task<IActionResult> Post([FromBody] Equipamentos equip)
        {
            try
            {
                await Database.CreateEquipTable();
                var teste = await Database.InsertEquipData(equip);
                return Ok(teste);
            }
            catch
            {
                throw;
            }


        }

        // PUT api/<ValuesController>/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody] string value)
        {
        }

        // DELETE api/<ValuesController>/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }
    }
}
