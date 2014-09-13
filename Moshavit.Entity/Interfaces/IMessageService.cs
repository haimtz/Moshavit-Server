using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Moshavit.Entity.EntityTable;

namespace Moshavit.Entity.Interfaces
{
    public interface IMessageService<T> where T : MessageTable
    {
        void AddNewMessage(T message);

        void UpdateMessage(T message);

        void DeleteMessage(T message);

        T GetMessage(int id);

        IEnumerable<T> GetAllMessages();
    }
}
