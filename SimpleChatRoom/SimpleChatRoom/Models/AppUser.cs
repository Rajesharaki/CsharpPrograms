using Microsoft.AspNetCore.Identity;
using System.Collections;
using System.Collections.Generic;

namespace SimpleChatRoom.Models
{
    public class AppUser:IdentityUser
    {
        public AppUser()
        {
            Messages = new HashSet<Messages>();
        }
        public virtual ICollection<Messages> Messages { get; set;}
    }
}
