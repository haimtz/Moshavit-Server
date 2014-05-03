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
        private readonly IRepository<Message> _repository;

        public MessageService(IRepository<Message> repository)
        {
            _repository = repository;
        }

        /// <summary>
        /// Add new message to database
        /// </summary>
        /// <param name="message">New Message</param>
        public bool AddNewMessage(Message message)
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
        public bool UpdateMessage(Message message)
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
        public bool DeleteMessage(Message message)
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
        public IEnumerable<Message> GetAllMessages()
        {
            return _repository.GetAll().ToList();
        }

        public IEnumerable<TK> GetMessagesByType<TK>() where TK : Message
        {
            return _repository.GetAllByType<TK>().ToList();
        }
    }
}
