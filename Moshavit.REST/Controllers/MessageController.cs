using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using Moshavit.Entity;
using Moshavit.Entity.EntityTable;
using Moshavit.Entity.Interfaces;
using Moshavit.Entity.TableEntity;

namespace Moshavit.REST.Controllers
{
    public class MessageController : ApiController
    {
        private readonly IMessageService _service;
        public MessageController(IMessageService service)
        {
            _service = service;
        }

        // GET api/<controller>
        public IEnumerable<MessageTable> Get()
        {
           // return _service.GetAllMessages();
            return _service.GetMessagesByType<BabySitterTable>();
        }

        // GET api/<controller>/5
        //public string Get(int id)
        //{
        //    return "value";
        //}

        // POST api/<controller>
        public HttpResponseMessage Post([FromBody]MessageTable message)
        {
            return _service.AddNewMessage(message) ? 
                Request.CreateResponse(HttpStatusCode.OK) : 
                Request.CreateErrorResponse(HttpStatusCode.BadRequest, "Error has been occurred");
        }

        // PUT api/<controller>/5
        public void Put(int id, [FromBody]MessageTable message)
        {
        }

        // DELETE api/<controller>/5
        public void Delete(int id)
        {
        }
    }
}