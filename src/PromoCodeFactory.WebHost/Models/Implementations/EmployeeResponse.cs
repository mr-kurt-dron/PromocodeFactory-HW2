using PromoCodeFactory.WebHost.Models.Abstractions;

namespace PromoCodeFactory.WebHost.Models.Implementations
{
    public class EmployeeResponse : ModelResponse
    {   
        public string FullName { get; set; }

        public string Email { get; set; }
    }
}