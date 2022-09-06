using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace PayzeeCaseStudy.LoginService.DTO
{
    public class LoginResponse
    {
        public bool Fail { get; set; }
        public HttpStatusCode StatusCode { get; set; }
        public LoginResponseResult Result { get; set; }
        public string Count { get; set; }
        public string ErrorCode { get; set; }
        public string ErrorDescription { get; set; }

        public class LoginResponseResult
        {
            public string UserId { get; set; }
            public string Token { get; set; }
        }
    }
}
