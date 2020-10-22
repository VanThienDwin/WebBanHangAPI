using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SaleWebsiteAPI.Model
{
    public class Chat
    {
        public int id { get; set; }
        public DateTime createDate { get; set; }
        public string content { get; set; }
        public Guid senderId { get; set; }
        public AppUser sender { get; set; }
        public Guid receiverId { get; set; }
        public AppUser receiver { get; set; }
    }
}
