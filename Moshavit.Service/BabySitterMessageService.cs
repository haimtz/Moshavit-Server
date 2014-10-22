using System;
using Moshavit.Entity;
using Moshavit.Entity.Dto.messages;
using Moshavit.Mapper;

namespace Moshavit.Service
{
    public class BabySitterMessageService : MessageService<BabySitterTable, BabySitterMessageDto>
    {
        public BabySitterMessageService(IDataBase<BabySitterTable> repository, IMapperType mapper, IUserService userService) : base(repository, mapper, userService)
        {
        }

        public void AddBabySitterMesage(BabySitterMessageDto message)
        {
            IsDateValid(message.StartTime, message.EndTime);

            AddNewMessage(message);
        }

        public void UpdateBabySitterMessage(BabySitterMessageDto message)
        {
            IsDateValid(message.StartTime, message.EndTime);

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
