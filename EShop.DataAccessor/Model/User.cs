using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Identity;

namespace EShop.DataAccessor.Model
{
    public class User : IdentityUser<int>
    {
        public virtual List<Order> Orders { get; set; }
    }
}