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
    public class BabySitterController : MessagesController<BabySitterTable>
    {
        public BabySitterController(IMessageService<BabySitterTable> service, IUserService userService)
            : base(service, userService)
        {
        }

        /// <summary>
        /// Get single message
        /// </summary>
        /// <param name="id">message id</param>
        /// <returns>babysitter message HttpStatus code 200</returns>
        [HttpGet]
        public HttpResponseMessage GetMessage(int id)
        {
            BabySitterTable message;
            UserData user;
            try
            {
                message = base.Get(id);
                user = UserService.GetUser(message.IdUser);
            }
            catch (Exception ex)
            {
                return Request.CreateErrorResponse(HttpStatusCode.BadRequest, ex.Message);
            }
            

            var result = new BabySitterMessageDto
            {
                IdMessage = message.IdMessage,
                IdUser = message.IdUser,
                Title = message.Title,
                Content = message.Content,
                StarTime = message.StartTime,
                EndTime = message.EndTime,
                Rate = message.Rate,
                Name = user.FirstName + " " + user.LastName,
                Phone = user.Phone
            };

            return Request.CreateResponse(HttpStatusCode.OK, result);
        }

        /// <summary>
        /// Add new babysitter ad
        /// </summary>
        /// <param name="message"></param>
        /// <returns></returns>
        public override HttpResponseMessage Post([FromBody]BabySitterTable message)
        {
            return base.Post(message);
        }

    }
}