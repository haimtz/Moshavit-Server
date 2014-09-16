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
        public BabySitterController(IMessageService<BabySitterTable, BabySitterMessageDto> service)
            : base(service)
        {

        }
    }
}