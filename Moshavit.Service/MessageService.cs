using System;
using System.CodeDom;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Moshavit.DataBase;
using Moshavit.Entity;
using Moshavit.Entity.Dto;
using Moshavit.Entity.Dto.messages;
using Moshavit.Entity.EntityTable;
using Moshavit.Entity.Interfaces;
using Moshavit.Mapper;

namespace Moshavit.Service
{
    public class MessageService<T, TK> : BaseRepository<T, TK>, IMessageService<T, TK>
        where T : MessageTable
        where TK : MessageBaseDto
    {

        private readonly IUserService _userService;
        #region Constructor
        public MessageService(IDataBase<T> repository, IMapperType mapper, IUserService userService):base(repository, mapper)
        {
            _userService = userService;
        }
        #endregion


        public void AddNewMessage(TK message)
        {
            message.ModifiedMessage = DateTime.Now;
            base.Add(message);
        }

        public TK GetMessage(int id)
        {
            var message = base.SelectFirst(x => x.IdMessage == id);
            var user = _userService.GetUser(message.IdUser);

            message.Name = user.FirstName + " " + user.LastName;
            message.Phone = user.Phone;

            return message;
        }

        public void UpdateMessage(TK message)
        {
            message.ModifiedMessage = DateTime.Now;
            base.Update(message);
        }

        public void DeleteMessage(int id)
        {
            var message = GetMessage(id);
            base.Delete(message);
        }

        public IEnumerable<TK> GetAllMessages()
        {
            var list = base.GetAll().ToList();

            foreach (var message in list)
            {
                var user = _userService.GetUser(message.IdUser);
                message.Name = user.FirstName + " " + user.LastName;
                message.Phone = user.Phone;
            }

            return list.OrderByDescending(x => x.ModifiedMessage);
        }
    }
}
