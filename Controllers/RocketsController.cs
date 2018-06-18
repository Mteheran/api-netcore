namespace ApiNetcore.Controllers
{
    using System.Collections.Generic;
    using ApiNetcore.Models;
    using Microsoft.AspNetCore.Mvc;

    [Route("api/[controller]")]
    public class RocketsController : Controller
    {
        // GET api/rockets
        [HttpGet]
        public IEnumerable<Rocket> Get() => Newtonsoft.Json.JsonConvert.DeserializeObject<List<Rocket>>(System.IO.File.ReadAllText("Data/rockets.json"));

        // GET api/rockets/5
        [HttpGet("{id}")]
        public Rocket Get(int id) => Newtonsoft.Json.JsonConvert.DeserializeObject<List<Rocket>>(System.IO.File.ReadAllText("Data/rockets.json")).Find(p=> p.Id == id);

        // POST api/rockets
        [HttpPost]
        public void Post([FromBody]Rocket value)
        {
            var listRockets = Newtonsoft.Json.JsonConvert.DeserializeObject<List<Rocket>>(System.IO.File.ReadAllText("Data/rockets.json"));

            listRockets.Add(value);

            System.IO.File.WriteAllText("Data/rockets.json", Newtonsoft.Json.JsonConvert.SerializeObject(listRockets));
        }

        // PUT api/rockets/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody]Rocket value)
        {
            var listRockets = Newtonsoft.Json.JsonConvert.DeserializeObject<List<Rocket>>(System.IO.File.ReadAllText("Data/rockets.json"));

            var rocketToUpdate = listRockets.Find(p => p.Id == id);

            listRockets[listRockets.IndexOf(listRockets.Find(p => p.Id == id))] = value;

            System.IO.File.WriteAllText("Data/rockets.json", Newtonsoft.Json.JsonConvert.SerializeObject(listRockets));
        }

        // PATCH api/rockets/5
        [HttpPatch("{id}")]
        public void Patch(int id, [FromBody]Rocket value)
        {
            var listRockets = Newtonsoft.Json.JsonConvert.DeserializeObject<List<Rocket>>(System.IO.File.ReadAllText("Data/rockets.json"));

            var rocketToUpdate = listRockets.Find(p => p.Id == id);
            var indexObject = listRockets.IndexOf(listRockets.Find(p => p.Id == id));

            listRockets[indexObject].Builder = value.Builder != null ? value.Builder : listRockets[indexObject].Builder;
            listRockets[indexObject].Target = value.Target != null ? value.Target : listRockets[indexObject].Target;
            listRockets[indexObject].Speed = value.Speed != null ? value.Speed : listRockets[indexObject].Speed;
            
            System.IO.File.WriteAllText("Data/rockets.json", Newtonsoft.Json.JsonConvert.SerializeObject(listRockets));

            string hola = $"hola a todos {Get(0)}";
        }

        // DELETE api/rockets/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
            var listRockets = Newtonsoft.Json.JsonConvert.DeserializeObject<List<Rocket>>(System.IO.File.ReadAllText("Data/rockets.json"));

            var rocketToUpdate = listRockets.Find(p => p.Id == id);

            listRockets.Remove(rocketToUpdate);

            System.IO.File.WriteAllText("Data/rockets.json", Newtonsoft.Json.JsonConvert.SerializeObject(listRockets));
        }
    }
}
