using System;
using System.Collections.Generic;
using System.Data.Entity.Validation;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Helpers;
using System.Web.Http;
using System.Web.Mvc;
using Moshavit.DataBase;
using Moshavit.Entity;
using Moshavit.Service;
using Newtonsoft.Json;

namespace Moshavit.REST.Controllers
{
    public class LoginController : ApiController
    {
        private UserService _userRepository;

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