using PayzeeCaseStudy.NoneSecurePayService.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PayzeeCaseStudy.NoneSecurePayService.Apstract
{
    public interface INonesecurePayService
    {
        Task<NonesecurePayResponse> Payment(NonesecurePayRequest request);
    }
}
