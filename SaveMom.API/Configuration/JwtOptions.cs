using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SaveMom.API.Configuration
{
    public class JwtOptions
    {
        public const string SectionName = "Jwt";
        public string? SecretKey { get; set; }
        public string? Issuer { get; set; }
        public string? Audience { get; set; }
        public int ExpirationInMinutes { get; set; }
        public int ExpirationInDays { get; set; }
    }
}
