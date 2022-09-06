using PayzeeCaseStudy.KPSPublic.DTO;

namespace PayzeeCaseStudy.KPSPublic.Abstract
{
    public interface IIdentificationService
    {
        Task<bool> Verify(IdentificationDto identificationDto);
    }
}
