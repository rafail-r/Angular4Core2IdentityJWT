using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Angular4Core2IdentityJWT.Models.Entities
{
    public class OtherUser // this is a new role. Stored in a different class(table)
    {
        public int Id { get; set; }
        public string IdentityId { get; set; }
        public AppUser Identity { get; set; } // for navigation purposes
        public string Location { get; set; }
    }
}
