using Microsoft.AspNetCore.Identity;
using SaleWebsiteAPI.Enums;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace SaleWebsiteAPI.Model
{
    public class AppUser:IdentityUser<Guid>
    {
        public AppUser()
        {
            Orders = new List<Order>();
        }
        [Required]
        public string displayname { get; set; }
        public string phone { get; set; }
        public string address { get; set; }
        public string avatar { get; set; }
        public bool gender { get; set; }
        public DateTime birthDay { get; set; }

        [DefaultValue(ActionStatus.Display)]
        public ActionStatus status { get; set; }
        //relative n - 1
        public virtual ICollection<Order> Orders { get; set; }
    }
}
