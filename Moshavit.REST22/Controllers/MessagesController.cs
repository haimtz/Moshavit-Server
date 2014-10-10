using System;
using System.Collections.Generic;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using Moshavit.Entity.Dto.messages;
using Moshavit.Entity.EntityTable;
using Moshavit.Entity.Interfaces;

namespace Moshavit.REST.Controllers
{
    /// <summary>
    /// Message rest service for messages from type T
    /// </summary>
    /// <typeparam name="T">inherit from MessageTable</typeparam>
    /// <typeparam name="TK">Dto</typeparam>
    public class MessagesController<T, TK> : ApiController
        where T : MessageTable
        where TK : MessageBaseDto
    {
        #region Members
        protected readonly IMessageService<T, TK> Service;
        #endregion

        #region Constractur
        public MessagesController(IMessageService<T, TK> service)
        {
            Service = service;
        }
        #endregion

        #region Public Method
        /// <summary>
        /// Get all messages from type T
        /// </summary>
        /// <returns></returns>
        public virtual IEnumerable<TK> Get()
        {
            return Service.GetAllMessages();
        }

        /// <summary>
        /// Get single message
        /// </summary>
        /// <param name="id">message id</param>
        /// <returns>babysitter message HttpStatus code 200</returns>
        public HttpResponseMessage Get(int id)
        {
            try
            {
                var result = Service.GetMessage(id);
                return Request.CreateResponse(HttpStatusCode.OK, result);
            }
            catch (Exception ex)
            {
                return Request.CreateErrorResponse(HttpStatusCode.BadRequest, ex.Message);
            }

        }

        // POST api/<controller>
        /// <summary>
        /// Add new message from type T
        /// </summary>
        /// <param name="message">new message</param>
        /// <returns>Http response 200</returns>
        public virtual HttpResponseMessage Post(TK message)
        {
            try
            {
                Service.AddNewMessage(message);
            }
            catch (Exception)
            {
                return Request.CreateErrorResponse(HttpStatusCode.BadRequest, "Error has been occurred");
            }

            return Request.CreateResponse(HttpStatusCode.OK);
        }

        /// <summary>
        /// Update message from type T
        /// </summary>
        /// <param name="message">message to update</param>
        /// <returns>http response 200</returns>
        public virtual HttpResponseMessage Put(TK message)
        {
            try
            {
                Service.UpdateMessage(message);
            }
            catch (Exception)
            {

                return Request.CreateErrorResponse(HttpStatusCode.BadRequest, "Error has been occurred");
            }
            return Request.CreateResponse(HttpStatusCode.OK);
        }


        /// <summary>
        /// Remove message from system
        /// </summary>
        /// <param name="id">id message</param>
        /// <returns>http response 200</returns>
        public virtual HttpResponseMessage Delete(int id)
        {
            try
            {
                Service.DeleteMessage(id);
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