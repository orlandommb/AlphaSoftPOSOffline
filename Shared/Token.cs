using System;
using System.Collections.Generic;
using System.Security.Claims;
using Microsoft.IdentityModel.Tokens;

namespace Shared
{
    public class Token
    {
        public string AccessToken { get; set; }
        public string Issuer { get; set; }
        public string Audience { get; set; }
        public IEnumerable<Claim> Claims { get; set; }
        public DateTime? Expires { get; set; }
        public SigningCredentials SigningCredentials { get; set; }
    }
}
