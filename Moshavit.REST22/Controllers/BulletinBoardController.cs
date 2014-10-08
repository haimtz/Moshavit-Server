using Moshavit.Entity;
using Moshavit.Entity.Dto.messages;
using Moshavit.Entity.Interfaces;

namespace Moshavit.REST.Controllers
{
    public class BulletinBoardController : MessagesController<BulletinBoardTable, BulletinBoardDto>
    {
        public BulletinBoardController(IMessageService<BulletinBoardTable, BulletinBoardDto> service) : base(service)
        {
        }
    }
}