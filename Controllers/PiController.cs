using Microsoft.AspNetCore.Mvc;
using System.Collections.Concurrent;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace loadbalancer_simpleapp_csharp.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PiController : ControllerBase
    {
        // GET: api/<PiController>
        //[HttpGet]
        //public IEnumerable<string> Get()
        //{
        //    return new string[] { "value1", "value2" };
        //}

        // GET api/<PiController>/5
        [HttpGet("{steps}")]
        public IResult Get(int steps)
        {
            if (steps <= 0 || steps > 999999999)
            {
                return Results.BadRequest("0 < n < 999999999");
            }
            double sum = 0.0;
            double step = 1.0 / steps;
            object obj = new();
            Parallel.ForEach(
                Partitioner.Create(0, steps),
                () => 0.0,
                (range, state, partial) =>
                {
                    for (int i = range.Item1; i < range.Item2; i++)
                    {
                        double x = (i - 0.5) * step;
                        partial += 4.0 / (1.0 + x * x);
                    }

                    return partial;
                },
                partial => { lock (obj) sum += partial; }
            );

            return Results.Ok((step * sum).ToString());
        }

        // POST api/<PiController>
        //[HttpPost]
        //public void Post([FromBody] string value)
        //{
        //}

        // PUT api/<PiController>/5
        //[HttpPut("{id}")]
        //public void Put(int id, [FromBody] string value)
        //{
        //}

        // DELETE api/<PiController>/5
        //[HttpDelete("{id}")]
        //public void Delete(int id)
        //{
        //}
    }
}
