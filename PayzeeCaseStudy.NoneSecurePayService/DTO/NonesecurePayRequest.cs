using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PayzeeCaseStudy.NoneSecurePayService.DTO
{
    public class NonesecurePayRequest
    {
        public string Password => "kU8@iP3@";
        public string Email => "murat.karayilan@dotto.com.tr";
        public string Lang => "TR";
        public string ApiKey => "SKI0NDHEUP60J7QVCFATP9TJFT2OQFSO";
        public long MemberId => 1;
        public long MerchantId => 1894;
        public string CustomerId => "1234";
        public string CardNumber { get; set; }
        public string ExpiryDateMonth { get; set; }
        public string ExpiryDateYear { get; set; }
        public string Cvv { get; set; }
        public string UserCode => "test";
        public string TxnType => "Auth";
        public string InstallmentCount => "1";
        public string Currency => "949";
        public string OrderId { get; set; }
        public string TotalAmount { get; set; }
        public string Rnd => new Random().Next(int.MinValue, int.MaxValue).ToString();
        public string Hash { get; internal set; }

    }
}
