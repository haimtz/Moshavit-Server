﻿using System.Data.Entity.Validation;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Helpers;
using System.Web.Http;
using Moshavit.Entity;
using Moshavit.Exceptions;
using Moshavit.Service;

namespace Moshavit.REST.Controllers
{
    public class RegisterController : ApiController
    {
        private readonly UserService _db;

        #region Constructor
        public RegisterController(UserService dbRepository)
        {
            _db = dbRepository;
        }
        #endregion

        #region REST Method
        [HttpPost]
        public HttpResponseMessage Post([FromBody]User user)
        {
            try
            {
                _db.Register(user);
            }
            catch(DbEntityValidationException dbEx)
            {
                var errors = (from validationErrors in dbEx.EntityValidationErrors
                              from validationError in validationErrors.ValidationErrors
                              select validationError.ErrorMessage).ToList();

                return Request.CreateErrorResponse(HttpStatusCode.BadRequest, Json.Encode(errors));
            }
            catch (RegistrationException ex)
            {
                return Request.CreateErrorResponse(HttpStatusCode.BadRequest, ex.Message);
            }

            return Request.CreateResponse(HttpStatusCode.OK);
        }
        #endregion
    }
}