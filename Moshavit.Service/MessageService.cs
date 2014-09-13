using System;
using System.CodeDom;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Moshavit.Entity;
using Moshavit.Entity.EntityTable;
using Moshavit.Entity.Interfaces;

namespace Moshavit.Service
{
    public class MessageService<T> : IMessageService<T> where T : MessageTable
    {
        private readonly IDataBase<T> _repository;

        #region Constructor
        public MessageService(IDataBase<T> repository)
        {
            _repository = repository;
        }
        #endregion


        public void AddNewMessage(T message)
        {
            _repository.Add(message);
        }

        public void UpdateMessage(T message)
        {
            _repository.Update(message);
        }

        public void DeleteMessage(T message)
        {
            _repository.Delete(message);
        }

        public T GetMessage(int id)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<T> GetAllMessages()
        {
            return _repository.GetAll();
        }
    }
}
