using PayzeeCaseStudy.LoginService.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PayzeeCaseStudy.LoginService.Abstract
{
    public interface ILoginService
    {
        Task<LoginResponse> Login();
    }
}
