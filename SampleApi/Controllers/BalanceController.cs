using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using SampleApi.Models;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace SampleApi.Controllers
{
    [Route("api/[controller]")]
    public class BalanceController : Controller
    {
        List<DataModel> values = new List<DataModel> {
            new DataModel{ id = 0, name = "Bruno" },
            new DataModel{ id = 1, name = "Nathy" }
        };

        // GET:
        [HttpGet]
        public IEnumerable<DataModel> Get()
        {
            return this.values;
        }

        // GET
        [HttpGet("{id}")]
        public DataModel Get(int id)
        {
            return values[id];
        }

        // POST api/balance
        [HttpPost]
        public DataModel Post([FromBody]DataModel value)
        {
            values.Add(value);
            return value;
        }

        // PUT api/balance/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody]string value)
        {
        }

        // DELETE api/balance/5
        [HttpDelete("{id}")]
        public List<DataModel> Delete(int id)
        {
            var itemToRemove = values.Single(val => val.id == id);
            values.Remove(itemToRemove);
            return values;
        }
    }
}
