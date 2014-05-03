using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Moshavit.Entity;
using Moshavit.Entity.EntityTable;

namespace Moshavit.Service
{
    class MessageService
    {
        private readonly IRepository<MessageTable> _repository;

        #region Constructor
        public MessageService(IRepository<MessageTable> repository)
        {
            _repository = repository;
        }
        #endregion

        #region Public method
        /// <summary>
        /// Add new message to database
        /// </summary>
        /// <param name="message">New Message</param>
        public bool AddNewMessage(MessageTable message)
        {
            try
            {
                _repository.Add(message);
            }
            catch (Exception ex)
            {
                return false;
            }
            return true;
        }

        /// <summary>
        /// Update Message Service
        /// </summary>
        /// <param name="message">Exist Message</param>
        public bool UpdateMessage(MessageTable message)
        {
            try
            {
                _repository.Update(message);
            }
            catch (Exception ex)
            {
                return false;
            }

            return true;
        }

        /// <summary>
        /// Delete Existing message 
        /// </summary>
        /// <param name="message"></param>
        public bool DeleteMessage(MessageTable message)
        {
            try
            {
                _repository.Delete(message);
            }
            catch (Exception ex)
            {
                return false;
            }

            return true;
        }

        /// <summary>
        /// Get all messages for database
        /// </summary>
        /// <returns>List Messages</returns>
        public IEnumerable<MessageTable> GetAllMessages()
        {
            return _repository.GetAll().ToList();
        }

        public IEnumerable<TK> GetMessagesByType<TK>() where TK : MessageTable
        {
            return _repository.GetAllByType<TK>().ToList();
        }
        #endregion
    }
}
