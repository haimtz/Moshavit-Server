using System;

namespace Moshavit.Entity.Dto.messages
{
    public class MessageBaseDto
    {
        public int IdMessage { get; set; }
        public int IdUser { get; set; }
        public string Title { get; set; }
        public string Content { get; set; }
        public string Name { get; set; }
        public string Phone { get; set; }
        public DateTime ModifiedMessage { get; set; }
    }
}
