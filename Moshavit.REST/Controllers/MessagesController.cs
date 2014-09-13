using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using Moshavit.Entity.EntityTable;
using Moshavit.Entity.Interfaces;

namespace Moshavit.REST.Controllers
{
    public abstract class MessagesController<T> : ApiController where T : MessageTable
    {
        private readonly IMessageService<T> _service;

        protected MessagesController(IMessageService<T> service)
        {
            _service = service;
        }

        public virtual IEnumerable<T> Get()
        {
            return _service.GetAllMessages();
        }

        // POST api/<controller>
        public virtual HttpResponseMessage Post(T message)
        {
            try
            {
                _service.AddNewMessage(message);
            }
            catch (Exception)
            {
                return Request.CreateErrorResponse(HttpStatusCode.BadRequest, "Error has been occurred");
            }

            return Request.CreateResponse(HttpStatusCode.OK);
        }

        public virtual HttpResponseMessage Put(T message)
        {
            try
            {
                _service.UpdateMessage(message);
            }
            catch (Exception)
            {

                return Request.CreateErrorResponse(HttpStatusCode.BadRequest, "Error has been occurred");
            }
            return Request.CreateResponse(HttpStatusCode.OK);
        }

        public virtual HttpResponseMessage Delete(int id)
        {
            throw new Exception();
        }
    }
}