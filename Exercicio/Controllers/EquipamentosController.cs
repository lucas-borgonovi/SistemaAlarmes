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

        
        // GET: api/<EquipamentosController>
        [HttpGet]
        public string GetEquipNames()
        {
            var result = Database.GetAllEquipsNames();

            string jsonTable = JsonConvert.SerializeObject(result);

            return jsonTable;
        }

        // GET api/<EquipamentosController>/5
        [HttpGet("{id}")]
        public string Get(int id)
        {
            return "value";
        }

        // POST api/<EquipamentosController>
        [HttpPost]
        public async Task<IActionResult> Post([FromBody] Equipamentos equip)
        {
            try
            {
                await Database.CreateEquipTable();
                await Database.InsertEquipData(equip);
                return Ok();
            }
            catch
            {
                throw;
            }


        }

        // PUT api/<EquipamentosController>/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody] string value)
        {
        }

        // DELETE api/<EquipamentosController>/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }
    }
}
