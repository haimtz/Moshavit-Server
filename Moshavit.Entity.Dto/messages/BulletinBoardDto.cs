using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Moshavit.Entity.Dto.messages
{
    public class BulletinBoardDto : MessageBaseDto
    {
        public string Description { get; set; }
        public string Details { get; set; }
    }
}
