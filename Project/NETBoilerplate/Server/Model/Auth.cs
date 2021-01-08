using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace NETBoilerplate.Server.Model
{
    public class Auth
    {
        public string Secret { get; set; }
        public string ExpiryMinute { get; set; }
    }
}
