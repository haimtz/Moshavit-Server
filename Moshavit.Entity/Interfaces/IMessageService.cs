using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Moshavit.Entity.EntityTable;

namespace Moshavit.Entity.Interfaces
{
    public interface IMessageService
    {
        bool AddNewMessage(MessageTable message);

        bool UpdateMessage(MessageTable message);

        bool DeleteMessage(MessageTable message);

        IEnumerable<MessageTable> GetAllMessages();

        IEnumerable<TK> GetMessagesByType<TK>() where TK : MessageTable;
    }
}
