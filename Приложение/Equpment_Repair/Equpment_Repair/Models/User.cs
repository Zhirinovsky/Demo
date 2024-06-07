using System;
using System.Collections.Generic;

// Code scaffolded by EF Core assumes nullable reference types (NRTs) are not used or disabled.
// If you have enabled NRTs for your project, then un-comment the following line:
// #nullable disable

namespace Equpment_Repair
{
    public partial class User
    {
        public User()
        {
            RequestClient = new HashSet<Request>();
            RequestEmployee = new HashSet<Request>();
        }

        public int Id { get; set; }
        public string Login { get; set; }
        public string Password { get; set; }
        public int RoleId { get; set; }

        public virtual Role Role { get; set; }
        public virtual ICollection<Request> RequestClient { get; set; }
        public virtual ICollection<Request> RequestEmployee { get; set; }
    }
}
