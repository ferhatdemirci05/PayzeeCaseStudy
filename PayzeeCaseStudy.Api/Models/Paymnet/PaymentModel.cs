namespace PayzeeCaseStudy.Api.Models.Paymnet
{
    public class PaymentModel
    {
        public string CardNumber { get; set; }
        public string ExpiryDateMonth { get; set; }
        public string ExpiryDateYear { get; set; }
        public string Cvv { get; set; }
    }
}
