using System.Collections.Generic;
using ApiNetcore.Models;
using Microsoft.AspNetCore.Mvc;

namespace ApiNetcore.Controllers
{
    [Route("api/[controller]")]
    public class RocketController : Controller
    {
        // GET api/values
        [HttpGet]
        public IEnumerable<Rocket> Get() => Newtonsoft.Json.JsonConvert.DeserializeObject<List<Rocket>>(System.IO.File.ReadAllText("Data/rockets.json"));

        // GET api/values/5
        [HttpGet("{id}")]
        public Rocket Get(int id) => Newtonsoft.Json.JsonConvert.DeserializeObject<List<Rocket>>(System.IO.File.ReadAllText("Data/rockets.json")).Find(p=> p.Id == id);

        // POST api/values
        [HttpPost]
        public void Post([FromBody]string value)
        {
        }

        // PUT api/values/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody]string value)
        {
        }

        // DELETE api/values/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }
    }
}
