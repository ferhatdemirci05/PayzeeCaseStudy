using Microsoft.Extensions.Options;
using Newtonsoft.Json;
using PayzeeCaseStudy.LoginService.Abstract;
using PayzeeCaseStudy.NoneSecurePayService.Apstract;
using PayzeeCaseStudy.NoneSecurePayService.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http.Headers;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;

namespace PayzeeCaseStudy.NoneSecurePayService.Concreate
{
    public class NonesecurePayService:INonesecurePayService
    {
        private readonly ILoginService _loginService;
        private readonly IHttpClientFactory _httpClientFactory;

        public NonesecurePayService(ILoginService loginService, 
                                    IHttpClientFactory httpClientFactory)
        {
            _loginService = loginService;   
            _httpClientFactory = httpClientFactory;
        }

        public async Task<NonesecurePayResponse> Payment(NonesecurePayRequest request)
        {
            var authentication = await _loginService.Login();
            var token = authentication.Result.Token;

            var client = _httpClientFactory.CreateClient("PayzeeNonesecurePaymentService");

            request.Hash = CreateHash(new HashParams
            {
                Password = request.Password,
                CustomerId = request.CustomerId,
                FailUrl = "https://localhost/fail",
                OkUrl = "https://localhost/ok",
                OrderId = request.OrderId,
                Rnd = request.Rnd,
                TotalAmount = request.TotalAmount,
                TxnType = request.TxnType,
                UserCode = request.UserCode
            });

            client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", token);

            var dataJson = JsonConvert.SerializeObject(request);
            var content = new StringContent(dataJson, Encoding.UTF8, "application/json");
            var paymentResponse = await client.PostAsync("Payment/NoneSecurePayment", content);

            var result = await paymentResponse.Content.ReadAsStringAsync();

            return JsonConvert.DeserializeObject<NonesecurePayResponse>(result);
        }

        internal string CreateHash(HashParams request)
        {

            var hashString =$"{request.Password}{request.UserCode}{request.Rnd}{request.TxnType}{request.TotalAmount}{ request.CustomerId}{ request.OrderId}{ request.OkUrl}{request.FailUrl}";

            var s512 = SHA512.Create();
            var byteConverter = new UnicodeEncoding();
            var bytes = s512.ComputeHash(byteConverter.GetBytes(hashString));
            var hash = BitConverter.ToString(bytes).Replace("-", " ");
            return hash;
        }
    }
}
