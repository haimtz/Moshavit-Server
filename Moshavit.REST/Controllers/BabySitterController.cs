using System;
using System.Collections.Generic;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using Moshavit.Entity;
using Moshavit.Entity.EntityTable;
using Moshavit.Entity.Interfaces;

namespace Moshavit.REST.Controllers
{
    public class BabySitterController : MessagesController<BabySitterTable>
    {
        public BabySitterController(IMessageService<BabySitterTable> service) 
            : base(service)
        {
        }

        public override HttpResponseMessage Post([FromBody]BabySitterTable message)
        {
            return base.Post(message);
        }
    }
}