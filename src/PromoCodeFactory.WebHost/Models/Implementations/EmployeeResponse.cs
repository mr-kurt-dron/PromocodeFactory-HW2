using PromoCodeFactory.WebHost.Models.Abstractions;
using System;

namespace PromoCodeFactory.WebHost.Models.Implementations
{
    public class EmployeeResponse : ModelResponse
    {   
        public string FullName { get; set; }

        public string Email { get; set; }
    }
}