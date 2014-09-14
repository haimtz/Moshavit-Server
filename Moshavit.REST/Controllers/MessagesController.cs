using System;
using System.Collections.Generic;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using Moshavit.Entity;
using Moshavit.Entity.EntityTable;
using Moshavit.Entity.Interfaces;
using Moshavit.Service;

namespace Moshavit.REST.Controllers
{
    /// <summary>
    /// Message rest service for messages from type T
    /// </summary>
    /// <typeparam name="T">inherit from MessageTable</typeparam>
    public abstract class MessagesController<T> : ApiController where T : MessageTable
    {
        #region Members
        protected readonly IMessageService<T> Service;
        protected readonly IUserService UserService;
        #endregion

        #region Constractur
        protected MessagesController(IMessageService<T> service, IUserService userService)
        {
            Service = service;
            UserService = userService;
        }
        #endregion

        #region Public Method
        /// <summary>
        /// Get all messages from type T
        /// </summary>
        /// <returns></returns>
        public virtual IEnumerable<T> Get()
        {
            return Service.GetAllMessages();
        }

        protected virtual T Get(int id)
        {
            return Service.GetMessage(id);
        }

        // POST api/<controller>
        /// <summary>
        /// Add new message from type T
        /// </summary>
        /// <param name="message">new message</param>
        /// <returns>Http response 200</returns>
        public virtual HttpResponseMessage Post(T message)
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
        public virtual HttpResponseMessage Put(T message)
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
            throw new Exception();
        }
        #endregion
    }
}