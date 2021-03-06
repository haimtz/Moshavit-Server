﻿using System;
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
        public HttpResponseMessage Put(UserRegistertionData user)
        {
            UserData updateUser;
            try
            {
                var oldDetails = _userService.GetUser(user.IdUser);
                user.StartTime = oldDetails.StartTime;
                updateUser = _userService.UpdateUser(user);
            }
            catch (Exception exception)
            {
                return Request.CreateErrorResponse(HttpStatusCode.BadRequest, exception.Message);
            }

            return Request.CreateResponse(HttpStatusCode.OK, updateUser);
        }

        // DELETE api/<controller>/5
        public HttpResponseMessage Delete(int id)
        {
            throw new Exception();
        }
    }
}