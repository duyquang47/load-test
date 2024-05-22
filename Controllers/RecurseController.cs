using Microsoft.AspNetCore.Mvc;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace loadbalancer_simpleapp_csharp.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class RecurseController : ControllerBase
    {
        // GET: api/<RecurseController>
        //[HttpGet]
        //public IEnumerable<string> Get()
        //{
        //    return new string[] { "value1", "value2" };
        //}

        // GET api/<RecurseController>/5
        [HttpGet("{n}")]
        public IResult Get(int n)
        {
            if (n <= 0 || n > 24)
            {
                return Results.BadRequest("0 < n < 25");
            }
            var list = (List<Int128>)[0, 1, 2, 3, 4, 5];
            var output = Recursive(list, n);
            var ostr = output.Count > 10000 ? string.Join(",", output.GetRange(0, 10000)) + "..." : string.Join(",", output);
            return Results.Ok(ostr);
        }

        public static Int128 Factorial(Int128 n)
        {
            if (n == 0)
            {
                return 1;
            }
 
            return n * Factorial(n - 1);
        }
        public static List<Int128> Recursive(List<Int128> list, Int128 n)
        {
            if (n <= 0)
            {
                return list;
            }
            var j = list.Count;
            var a = list;
            for (var i = 0; i < j; i++)
            {
                a.Add(Factorial(n));
            }
            n--;
            Recursive(list, n);
            return list;
        }

        // POST api/<RecurseController>
        //[HttpPost]
        //public void Post([FromBody] string value)
        //{
        //}

        // PUT api/<RecurseController>/5
        //[HttpPut("{id}")]
        //public void Put(int id, [FromBody] string value)
        //{
        //}

        // DELETE api/<RecurseController>/5
        //[HttpDelete("{id}")]
        //public void Delete(int id)
        //{
        //}
    }
}
