using System;
using System.Net;
using System.Net.Http;
using Moshavit.Entity.Dto.messages;
using Moshavit.Entity.EntityTable;
using Moshavit.Service;

namespace Moshavit.REST.Controllers
{
    public class CarpullController : MessagesController<CarPullTable, CarpullMessageDto>
    {
        public CarpullController(CarPullMessageService service)
            : base(service)
        {
        }

        public override HttpResponseMessage Post(CarpullMessageDto message)
        {
            try
            {
                CarPullService.CarPullAddMessage(message);
            }
            catch (Exception ex)
            {
                return Request.CreateErrorResponse(HttpStatusCode.BadRequest, ex.Message);
            }

            return Request.CreateResponse(HttpStatusCode.OK);
        }

        public override HttpResponseMessage Put(CarpullMessageDto message)
        {
            try
            {
                CarPullService.CarPullUpdateMessage(message);
            }
            catch (Exception ex)
            {
                return Request.CreateErrorResponse(HttpStatusCode.BadRequest, ex.Message);
            }

            return Request.CreateResponse(HttpStatusCode.OK);
        }

        private CarPullMessageService CarPullService
        {
            get { return ((CarPullMessageService) Service); }
        }
    }
}