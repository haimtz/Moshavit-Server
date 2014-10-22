
using System;
using Moshavit.Entity;
using Moshavit.Entity.Dto.messages;
using Moshavit.Entity.EntityTable;
using Moshavit.Mapper;

namespace Moshavit.Service
{
    public class CarPullMessageService : MessageService<CarPullTable, CarpullMessageDto>
    {
        public CarPullMessageService(IDataBase<CarPullTable> repository, IMapperType mapper, IUserService userService)
            : base(repository, mapper, userService)
        {

        }

        public void CarPullAddMessage(CarpullMessageDto message)
        {
            IsDateValid(message.PickUp, message.ReturnTime);

            AddNewMessage(message);
        }

        public void CarPullUpdateMessage(CarpullMessageDto message)
        {
            IsDateValid(message.PickUp, message.ReturnTime);

            UpdateMessage(message);
        }

        private void IsDateValid(DateTime start, DateTime end)
        {
            if (start > end)
                throw new ArgumentException("End time is Earlier then Start Time");

            if (IsraelTimeZone.Now() > start)
                throw new ArgumentException("Start time as been pass");
        }
    }
}
