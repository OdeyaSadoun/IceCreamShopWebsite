using IceCreamProject.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace IceCreamProject.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class GraphDataController : ControllerBase
    {



        // GET: api/<graphDataController>
        [HttpGet]
        public ActionResult Get()
        {

            //גישה שניה ליצירת גרף העובדת בשיטה מקובלת
            //שירות זה מחזיר נתונים בפורמט 
            //json
            // אותם צורך הדף
            //graphpage.html
            // באמצעות קריאת 
            //AJAX
            //שנעשית בעזרת ספריית
            //JQUERY
            List<Data> data = new List<Data>
            {
                new Data {x=1,y=200},
                new Data {x=2,y=210},
                new Data {x=3,y=290},
                new Data {x=4,y=100}
            };
            return Ok(data);

        }

        // GET api/<graphDataController>/5
        [HttpGet("{id}")]
        public string Get(int id)
        {
            return "value";
        }

        // POST api/<graphDataController>
        [HttpPost]
        public void Post([FromBody] string value)
        {
        }

        // PUT api/<graphDataController>/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody] string value)
        {
        }

        // DELETE api/<graphDataController>/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }

    }
}
