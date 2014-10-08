using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using Moshavit.Entity;
using Moshavit.Entity.Dto.messages;
using Moshavit.Entity.EntityTable;
using Moshavit.Entity.Interfaces;

namespace Moshavit.REST.Controllers
{
    public class GiveAndTakeController : MessagesController<GiveAndTakeTable, GiveAndTakeDto>
    {
        public GiveAndTakeController(IMessageService<GiveAndTakeTable, GiveAndTakeDto> service) : base(service)
        {
        }
    }
}