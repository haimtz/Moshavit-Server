using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Moshavit.Entity.Dto.messages
{
    public class CarpullMessageDto : MessageBaseDto
    {
        public string From { get; set; }
        public string To { get; set; }
        public DateTime PickUp { get; set; }
        public DateTime ReturnTime { get; set; }
    }
}
