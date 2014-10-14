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

        // PUT api/<controller>/5
        public HttpResponseMessage Put(UserRegistertionData user)
        {
            UserData updatedUser;
            try
            {
                updatedUser = _userService.UpdateUser(user);
            }
            catch (Exception exception)
            {
                return Request.CreateErrorResponse(HttpStatusCode.BadRequest, exception.Message);
            }

            return Request.CreateResponse(HttpStatusCode.OK, updatedUser);
        }

        // DELETE api/<controller>/5
        public HttpResponseMessage Delete(int id)
        {
            try
            {
                _userService.DeleteUser(id);
            }
            catch (Exception ex)
            {
                return Request.CreateErrorResponse(HttpStatusCode.BadRequest, ex.Message);
            }

            return Request.CreateResponse(HttpStatusCode.OK);
        }
    }
}