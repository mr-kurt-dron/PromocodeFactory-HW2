using PromoCodeFactory.WebHost.Models.Abstractions;
using System;
using System.Collections.Generic;

namespace PromoCodeFactory.WebHost.Models.Implementations
{
    public class EmployeeFullResponse : EmployeeResponse
    {
        public List<RoleItemResponse> Roles { get; set; }

        public int AppliedPromocodesCount { get; set; }
    }
}