namespace ApiNetcore.Controllers
{
    using ApiNetcore.Models;
    using Microsoft.AspNetCore.Mvc;
    using System.Collections.Generic;

    public class RocketsRouteController : Controller
    {
        // GET api/rocketsroute
        [HttpGet("api/rocketsroute")]
        public IEnumerable<Rocket> Get() => Newtonsoft.Json.JsonConvert.DeserializeObject<List<Rocket>>(System.IO.File.ReadAllText("Data/rockets.json"));

        // GET api/rocketsroute/5
        [HttpGet]
        public Rocket Get(int id) => Newtonsoft.Json.JsonConvert.DeserializeObject<List<Rocket>>(System.IO.File.ReadAllText("Data/rockets.json")).Find(p => p.Id == id);

        // POST api/rocketsroute
        [Route("api/[controller]")]
        [HttpPost]
        public void Post([FromBody]Rocket value)
        {
            var listRockets = Newtonsoft.Json.JsonConvert.DeserializeObject<List<Rocket>>(System.IO.File.ReadAllText("Data/rockets.json"));

            listRockets.Add(value);

            System.IO.File.WriteAllText("Data/rockets.json", Newtonsoft.Json.JsonConvert.SerializeObject(listRockets));
        }

        // PUT api/rocketsroute/5
        [Route("api/rocketsroute/{id}")]
        [HttpPut("{id}")]
        public void Put(int id, [FromBody]Rocket value)
        {
            var listRockets = Newtonsoft.Json.JsonConvert.DeserializeObject<List<Rocket>>(System.IO.File.ReadAllText("Data/rockets.json"));

            var rocketToUpdate = listRockets.Find(p => p.Id == id);

            listRockets[listRockets.IndexOf(listRockets.Find(p => p.Id == id))] = value;

            System.IO.File.WriteAllText("Data/rockets.json", Newtonsoft.Json.JsonConvert.SerializeObject(listRockets));
        }

        // PATCH api/rocketsroute/5
        [Route("api/rocketsroute/{id}")]
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

        // DELETE api/rocketsroute/5
        [Route("api/rocketsroute/{id}")]
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