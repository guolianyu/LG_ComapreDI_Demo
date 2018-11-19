using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;

namespace IOCDemo.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ValuesController : ControllerBase
    {
        private readonly LGDbContext _lGDbContext;
        public ValuesController(LGDbContext lGDbContext)
        {
            _lGDbContext = lGDbContext;
        }
        // GET api/values
        [HttpGet]
        public ActionResult<IEnumerable<string>> Get(int workid, string pwd)
        {
            Stopwatch sw = new Stopwatch();
            sw.Start();
            var user = _lGDbContext.User.FirstOrDefault(a => a.WorkId == workid && a.Pwd == pwd);
            sw.Stop();
            TimeSpan ts2 = sw.Elapsed;
            Console.WriteLine("Stopwatch总共花费{0}s.", ts2.TotalSeconds);
            return new string[] { "value1", "value2" };
        }

        // GET api/values/5
        [HttpGet("{id}")]
        public ActionResult<string> Get(int id)
        {
            return "value";
        }

        // POST api/values
        [HttpPost]
        public void Post([FromBody] string value)
        {
        }

        // PUT api/values/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody] string value)
        {
        }

        // DELETE api/values/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }
    }
}
