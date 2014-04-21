using System.Web.Http;
using Moshavit.DataBase;
using Moshavit.Entity.TableEntity;

namespace Moshavit.REST.Controllers
{
    public class ValuesController : ApiController
    {
        private readonly Context _data;
        public ValuesController(Context data)
        {
            _data = data;
        }
        // GET api/<controller>
        public string Get()
        {
            var user = new UserTable { FirstName = "haim", LastName = "tz", Phone = "ioiop"};

            _data.Users.Add(user);
            _data.SaveChanges();
            return "OK";
        }

        // GET api/<controller>/5
        public string Get(int id)
        {
            return "value";
        }

        // POST api/<controller>
        public void Post([FromBody]string value)
        {
        }

        // PUT api/<controller>/5
        public void Put(int id, [FromBody]string value)
        {
        }

        // DELETE api/<controller>/5
        public void Delete(int id)
        {
        }

        class Message
        {
            public string message { get; set; }
            public string error { get; set; }
        }
    }
}