using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using Moshavit.Entity.Dto.User;
using Moshavit.Entity.Interfaces;
using Moshavit.Exceptions;

namespace Moshavit.REST22.Controllers
{
    public class ForgotPasswordController : ApiController
    {
        private readonly IForgotPasswordService _service;
        public ForgotPasswordController(IForgotPasswordService service)
        {
            _service = service;
        }
        // POST api/<controller>
        public HttpResponseMessage Post([FromBody]ForgotPasswordDto value)
        {
            try
            {
                _service.SendPassword(value.Email);
            }
            catch (UserException ex)
            {
                return Request.CreateResponse(HttpStatusCode.OK);
            }
            return Request.CreateResponse(HttpStatusCode.OK);
        }
    }
}