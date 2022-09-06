using Microsoft.AspNetCore.Mvc;
using PayzeeCaseStudy.Api.Models.Identication;
using PayzeeCaseStudy.KPSPublic.Abstract;
using PayzeeCaseStudy.KPSPublic.DTO;

namespace PayzeeCaseStudy.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class IdenticationController : ControllerBase
    {
        private readonly IIdentificationService _identificationService;

        public IdenticationController(IIdentificationService identificationService)
        {
            _identificationService = identificationService;
        }


        [Route("Verify")]
        [HttpPost]
        public async Task<IActionResult> Verify(VerifyModel verifyModel)
        {
            var resultVerify = await _identificationService.Verify(new IdentificationDto
            {
                FirstName = verifyModel.FirstName,
                LastName = verifyModel.LastName,
                IdentificationNo = verifyModel.IdentificationNo,
                YearOfBirth = verifyModel.YearOfBirth
            });

            return Ok(resultVerify);
        }
    }
}
