using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PayzeeCaseStudy.NoneSecurePayService.DTO
{
    internal class HashParams
    {
        public object UserCode { get; internal set; }
        public object Rnd { get; internal set; }
        public object TxnType { get; internal set; }
        public object TotalAmount { get; internal set; }
        public object CustomerId { get; internal set; }
        public object OrderId { get; internal set; }
        public object OkUrl { get; internal set; }
        public object FailUrl { get; internal set; }
        public object Password { get; internal set; }
    }
}
