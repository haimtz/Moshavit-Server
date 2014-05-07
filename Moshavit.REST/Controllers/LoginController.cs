using System;
using System.Collections.Generic;
using System.Data.Entity.Validation;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using Moshavit.Entity.EntityDTO;
using Moshavit.Service;

namespace Moshavit.REST.Controllers
{
    public class LoginController : ApiController
    {
        private readonly UserService _userRepository;

        public LoginController(UserService userRepository)
        {
            _userRepository = userRepository;
        }
        // POST api/<controller>
        public HttpResponseMessage Post([FromBody]UserLogin user)
        {
            string token;
            try
            {
                token =_userRepository.Login(user.Email, user.Password);
            }
            catch (Exception ex)
            {
                return Request.CreateErrorResponse(HttpStatusCode.BadRequest, ex.Message);
            }

            return Request.CreateResponse(HttpStatusCode.OK, token);
        }
    }
}