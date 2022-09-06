using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace PayzeeCaseStudy.NoneSecurePayService.DTO
{
    public class NonesecurePayResponse
    {
        public bool Fail { get; set; }
        public HttpStatusCode StatusCode { get; set; }
        public NonesecurePayResult Result { get; set; }

        public class NonesecurePayResult
        {
            public string ResponseCode { get; set; }
            public string ResponseMessage { get; set; }
            public string OrderId { get; set; }
            public string BankOrderNo { get; set; }
            public string TxnType { get; set; }
            public string TxnStatus { get; set; }
            public string TotalAmount { get; set; }
            public string VposId { get; set; }
            public string VposName { get; set; }
        }
    }

}
