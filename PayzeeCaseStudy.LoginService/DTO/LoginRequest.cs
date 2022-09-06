using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PayzeeCaseStudy.LoginService.DTO
{
    public class LoginRequest
    {
        public string ApiKey { get; set; }
        public string Email { get; set; }
        public string Lang { get; set; }
    }
}
