using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using Microsoft.Ajax.Utilities;
using Moshavit.Entity.Dto;
using Moshavit.Entity.Interfaces;

namespace Moshavit.REST.Controllers
{
    public class SurveyController : ApiController
    {
        #region Members
        private readonly ISurveyService _service;
        #endregion

        #region Constructor
        public SurveyController(ISurveyService service)
        {
            _service = service;
        }
        #endregion

        #region Public
        #region Get
        [HttpGet]
        public HttpResponseMessage Get()
        {
            try
            {
                var result = _service.GetAll();
                return Request.CreateResponse(HttpStatusCode.OK, result);
            }
            catch (Exception ex)
            {
                return Request.CreateErrorResponse(HttpStatusCode.BadRequest, ex.Message);
            }
        }

        [HttpGet]
        public HttpResponseMessage Get(int id)
        {
            try
            {
                var result = _service.GetSurvey(id);
                return Request.CreateResponse(HttpStatusCode.OK, result);
            }
            catch (Exception ex)
            {
                return Request.CreateErrorResponse(HttpStatusCode.BadRequest, ex.Message);
            }
        }
        #endregion

        [HttpPost]
        public HttpResponseMessage Post([FromBody]SurveyDto survey)
        {
            try
            {
                _service.AddSurvey(survey);
                return Request.CreateResponse(HttpStatusCode.OK);
            }
            catch (Exception ex)
            {
                return Request.CreateErrorResponse(HttpStatusCode.BadRequest, ex.Message);
            }
        }

        [HttpPut]
        public HttpResponseMessage Put([FromBody]SurveyDto survey)
        {
            try
            {
                _service.UpdateSurvey(survey);
                return Request.CreateResponse(HttpStatusCode.OK);
            }
            catch (Exception ex)
            {
                return Request.CreateErrorResponse(HttpStatusCode.BadRequest, ex.Message);
            }
        }

        // DELETE api/<controller>/5
        public HttpResponseMessage Delete(int id)
        {
            try
            {
                _service.DeleteSurvey(id);
            }
            catch (Exception ex)
            {
                return Request.CreateErrorResponse(HttpStatusCode.BadRequest, ex.Message);
            }

            return Request.CreateResponse(HttpStatusCode.OK);
        }
        #endregion
    }
}