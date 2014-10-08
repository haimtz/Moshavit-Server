using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using Moshavit.Entity.Dto;
using Moshavit.Entity.Interfaces;

namespace Moshavit.REST.Controllers
{
    public class VoteController : ApiController
    {
        private readonly ISurveyService _surveyService;
        public VoteController(ISurveyService surveyService)
        {
            _surveyService = surveyService;
        }

        [HttpPost]
        public HttpResponseMessage Post([FromBody]UserVote vote)
        {
            try
            {
                _surveyService.AddVote(vote);
                return Request.CreateResponse(HttpStatusCode.OK);
            }
            catch (Exception ex)
            {
                return Request.CreateErrorResponse(HttpStatusCode.BadRequest, ex.Message);
            }
        }
    }
}