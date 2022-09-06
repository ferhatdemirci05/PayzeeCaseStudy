using Microsoft.Extensions.Options;
using PayzeeCaseStudy.LoginService.Abstract;
using PayzeeCaseStudy.LoginService.DTO;
using System.Net.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;

namespace PayzeeCaseStudy.LoginService.Concreate
{
    public class LoginService : ILoginService
    {
        private readonly IHttpClientFactory _httpClientFactory;
        private readonly LoginRequest _loginRequest;
        public LoginService(IHttpClientFactory httpClientFactory, 
                            IOptions<LoginRequest> loginRequest)
        {
            _httpClientFactory = httpClientFactory;
            _loginRequest = loginRequest.Value;
        }

        public async Task<LoginResponse> Login()
        {
            var client = _httpClientFactory.CreateClient("PayzeeLoginService");
            var dataJson = JsonConvert.SerializeObject(_loginRequest);
            var content = new StringContent(dataJson, Encoding.UTF8, "application/json");

            var loginResponse = await client.PostAsync("Securities/authenticationMerchant", content);

            var result = await loginResponse.Content.ReadAsStringAsync();

            if (result == null)
                throw new NullReferenceException(result);

            return JsonConvert.DeserializeObject<LoginResponse>(result);
        }
    }
}
