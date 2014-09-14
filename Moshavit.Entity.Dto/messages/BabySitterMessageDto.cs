using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Moshavit.Entity.Dto.messages
{
    public class BabySitterMessageDto
    {
        public int IdMessage { get; set; }
        public int IdUser { get; set; }
        public string Title { get; set; }
        public string Content { get; set; }
        public double Rate { get; set; }
        public DateTime StarTime { get; set; }
        public DateTime EndTime { get; set; }
        public string Name { get; set; }
        public string Phone { get; set; }
    }
}
