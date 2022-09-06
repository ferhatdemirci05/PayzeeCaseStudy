using PayzeeCaseStudy.KPSPublic.Abstract;
using PayzeeCaseStudy.KPSPublic.DTO;

namespace PayzeeCaseStudy.KPSPublic.Concreate
{
    public class IdentificationService : IIdentificationService
    {
        private readonly KPSPublicSoapClient _kPSPublicSoap;
        public IdentificationService(KPSPublicSoapClient kPSPublicSoap)
        {
            _kPSPublicSoap = kPSPublicSoap;
        }
        public async Task<bool> Verify(IdentificationDto identificationDto)
        {
            try
            {
                var kPSPublicResponse = await _kPSPublicSoap.TCKimlikNoDogrulaAsync(
                    identificationDto.IdentificationNo,
                    identificationDto.FirstName,
                    identificationDto.LastName,
                    identificationDto.YearOfBirth);

                if (kPSPublicResponse != null && kPSPublicResponse.Body != null)
                {
                    return kPSPublicResponse.Body.TCKimlikNoDogrulaResult;
                }
            }
            catch (Exception)
            {
                // Ex logging;
            }
            return false;
        }
    }
}
