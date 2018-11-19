using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;

namespace AspectCoreDemo.Controllers
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
        public ActionResult<string> Get(int workid, string pwd)
        {
            Stopwatch sw = new Stopwatch();
            sw.Start();
            var user = _lGDbContext.User.FirstOrDefault(a => a.WorkId == workid && a.Pwd == pwd);
            sw.Stop();
            TimeSpan ts2 = sw.Elapsed;
            Console.WriteLine("Stopwatch总共花费{0}s.", ts2.TotalSeconds);
            return Ok();
        }
    }
}
