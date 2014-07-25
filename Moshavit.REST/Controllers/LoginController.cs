using System;
using System.Collections.Generic;
using System.Data.Entity.Validation;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using Moshavit.Entity.Dto;
using Moshavit.Entity.Dto;
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
        public HttpResponseMessage Post([FromBody]UserLoginDto user)
        {
            //TODO: need to return the user Id
            string token;
            try
            {
                _userRepository.Login(user);
            }
            catch (Exception ex)
            {
                return Request.CreateErrorResponse(HttpStatusCode.BadRequest, ex.Message);
            }

            return Request.CreateResponse(HttpStatusCode.OK);
        }
    }
}