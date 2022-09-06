using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using PayzeeCaseStudy.Api.Models.Paymnet;
using PayzeeCaseStudy.NoneSecurePayService.Apstract;
using PayzeeCaseStudy.NoneSecurePayService.DTO;

namespace PayzeeCaseStudy.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PaymentController : ControllerBase
    {
        private readonly INonesecurePayService _nonesecurePayService;
        public PaymentController(INonesecurePayService nonesecurePayService)
        {
            _nonesecurePayService = nonesecurePayService;
        }

        [Route("")]
        [HttpPost]
        public async Task<IActionResult> Payment(PaymentModel paymentModel)
        {
            var nonesecurePayRequest = new NonesecurePayRequest
            {
                CardNumber = paymentModel.CardNumber,
                ExpiryDateMonth = paymentModel.ExpiryDateMonth,
                ExpiryDateYear = paymentModel.ExpiryDateYear,
                Cvv = paymentModel.Cvv,
                OrderId = $"FD{DateTime.Now.Millisecond}"
            };

            var response = await _nonesecurePayService.Payment(nonesecurePayRequest);

            return Ok(response);
        }
    }
}
