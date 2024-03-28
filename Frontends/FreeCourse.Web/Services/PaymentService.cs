using FreeCourse.Web.Models.FakePayment;
using FreeCourse.Web.Services.Interfaces;

namespace FreeCourse.Web.Services
{
    public class PaymentService : IPaymentService
    {
        private readonly HttpClient _httpClient;

        public PaymentService(HttpClient httpClient)
        {
            _httpClient = httpClient;
        }

        public async Task<bool> ReceivePayment(PaymentInfoInput paymentInfoInput)
        {
            var response = await _httpClient.PostAsJsonAsync<PaymentInfoInput>("fakepayments", paymentInfoInput);
            if (!response.IsSuccessStatusCode)
            {
                // İsteğin başarısız olduğunda daha ayrıntılı hata bilgilerini elde etmek için
                var content = await response.Content.ReadAsStringAsync();
                Console.WriteLine($"Ödeme alınamadı. Hata kodu: {response.StatusCode}");
                Console.WriteLine($"Hata içeriği: {content}");
            }

            return response.IsSuccessStatusCode;
        }
    }
}
