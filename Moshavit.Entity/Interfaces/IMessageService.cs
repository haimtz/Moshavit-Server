using System.Collections.Generic;
using Moshavit.Entity.Dto.messages;

namespace Moshavit.Entity.Interfaces
{
    public interface IMessageService<T, TK> where TK : MessageBaseDto
    {
        void AddNewMessage(TK message);

        void UpdateMessage(TK message);

        void DeleteMessage(int id);

        TK GetMessage(int id);

        IEnumerable<TK> GetAllMessages();
    }
}
