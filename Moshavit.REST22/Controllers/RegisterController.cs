﻿using System.Data.Entity.Validation;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Helpers;
using System.Web.Http;
using Moshavit.Entity.Dto;
using Moshavit.Entity.Interfaces;
using Moshavit.Entity.TableEntity;
using Moshavit.Exceptions;
using Moshavit.Service;
using Newtonsoft.Json;

namespace Moshavit.REST.Controllers
{
    public class RegisterController : ApiController
    {
        private readonly IUserService _db;
        private readonly IWelcomeMailService _mailService;
        #region Constructor
        public RegisterController(IUserService dbRepository, IWelcomeMailService mailService)
        {
            _db = dbRepository;
            _mailService = mailService;
        }
        #endregion

        #region REST Method
        [HttpPost]
        public HttpResponseMessage Post([FromBody]UserRegistertionData user)
        {
            try
            {
                _db.Register(user);
                var userName = user.FirstName + " " + user.LastName;
                _mailService.SendWelcome(user.Email, userName);
            }
            catch(DbEntityValidationException dbEx)
            {
                var errors = (from validationErrors in dbEx.EntityValidationErrors
                              from validationError in validationErrors.ValidationErrors
                              select validationError.ErrorMessage).ToList();
                return Request.CreateErrorResponse(HttpStatusCode.BadRequest, JsonConvert.SerializeObject(errors));
            }
            catch (RegistrationException ex)
            {
                return Request.CreateErrorResponse(HttpStatusCode.BadRequest, ex.Message + " REST");
            }

            return Request.CreateResponse(HttpStatusCode.OK);
        }
        #endregion
    }
}