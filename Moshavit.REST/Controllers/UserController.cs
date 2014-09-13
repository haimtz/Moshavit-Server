using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using Moshavit.Entity.Dto;
using Moshavit.Service;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;

namespace Moshavit.REST.Controllers
{
    public class UserController : ApiController
    {
        private readonly IUserService _userService;

        public UserController(IUserService userService)
        {
            _userService = userService;
        }

        // GET api/<controller>
        public IEnumerable<UserData> Get()
        {
            return _userService.GetAllUsers();
        }

        // GET api/<controller>/5
        public HttpResponseMessage Get(int id)
        {
            UserData userData;
            try
            {
               userData =  _userService.GetUser(id);
            }
            catch (Exception)
            {
                return Request.CreateErrorResponse(HttpStatusCode.NotAcceptable, "User do not exist");
            }

            return Request.CreateResponse(HttpStatusCode.OK, userData);
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
    }
}