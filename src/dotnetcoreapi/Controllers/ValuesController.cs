using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using log4net;
using Microsoft.AspNetCore.Mvc;

namespace dotnetcoreapi.Controllers
{
    [Route("api/[controller]")]
    public class ValuesController : Controller
    {
        private static readonly ILog log = LogManager.GetLogger(typeof(ValuesController));

        // GET api/values
        [HttpGet]
        public IEnumerable<string> Get()
        {
            log.Debug("Get()");

            return new string[] { "value1", "value2" };
        }

        // GET api/values/5
        [HttpGet("{id}")]
        public string Get(int id)
        {
            log.Debug($"Get(id) id={id}");

            try
            {
                if (id < 0)
                    throw new ArgumentException("Id must be a positive integer.", nameof(id));

                return "value";
            }
            catch (Exception ex)
            {
                log.Error(ex.Message);

                throw;
            }
        }

        // POST api/values
        [HttpPost]
        public void Post([FromBody]string value)
        {
            log.Debug($"Post(value) value={value}");
        }

        // PUT api/values/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody]string value)
        {
            log.Debug($"Put(id, value) id={id}, value={value}");

            try
            {
                if (id < 0)
                    throw new ArgumentException("Id must be a positive integer.", nameof(id));

            }
            catch (Exception ex)
            {
                log.Error(ex.Message);

                throw;
            }
        }

        // DELETE api/values/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
            log.Debug($"Delete(id) id={id}");

            try
            {
                if (id < 0)
                    throw new ArgumentException("Id must be a positive integer.", nameof(id));

            }
            catch (Exception ex)
            {
                log.Error(ex.Message);

                throw;
            }
        }

        // GET api/values/division/9/3
        [HttpGet("division/{dividend}/{divisor}")]
        public IActionResult Division(int dividend, int divisor)
        {
            log.Debug($"Division(dividend, divisor) dividend={dividend}, divisor={divisor}");

            try
            {
                if (divisor != 0)
                {
                    return Ok(dividend / divisor);
                }
                else
                {
                    return BadRequest();
                }
            }
            catch (Exception ex)
            {
                log.Error(ex.Message);

                throw;
            }
        }
    }
}
