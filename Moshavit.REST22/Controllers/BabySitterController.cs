using System;
using System.Collections.Generic;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using Moshavit.Entity;
using Moshavit.Entity.Dto;
using Moshavit.Entity.Dto.messages;
using Moshavit.Entity.EntityTable;
using Moshavit.Entity.Interfaces;
using Moshavit.Service;

namespace Moshavit.REST.Controllers
{
    /// <summary>
    /// Babysitter rest service
    /// </summary>
    public class BabySitterController : MessagesController<BabySitterTable, BabySitterMessageDto>
    {
        public BabySitterController(BabySitterMessageService service)
            : base(service)
        {

        }

        public override HttpResponseMessage Post(BabySitterMessageDto message)
        {
            try
            {
                BabySitterService.AddBabySitterMesage(message);
            }
            catch (Exception ex)
            {
                return Request.CreateResponse(HttpStatusCode.BadRequest, ex.Message);
            }

            return Request.CreateResponse(HttpStatusCode.OK);
        }

        public override HttpResponseMessage Put(BabySitterMessageDto message)
        {
            try
            {
                BabySitterService.UpdateBabySitterMessage(message);
            }
            catch (Exception ex)
            {
                return Request.CreateErrorResponse(HttpStatusCode.BadRequest, ex.Message);
            }

            return Request.CreateResponse(HttpStatusCode.OK);
        }

        private BabySitterMessageService BabySitterService
        {
            get { return ((BabySitterMessageService)Service); }
        }
    }
}