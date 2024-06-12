using PromoCodeFactory.Core.Abstractions;
using PromoCodeFactory.Core.Domain.Administration;
using PromoCodeFactory.WebHost.Models.Abstraction;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PromoCodeFactory.WebHost.Models.Implementations
{
    public class EmployeeRequest : ModelRequest
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }

        public string Email { get; set; }

        public List<Guid> RolesId { get; set; }

        public int AppliedPromocodesCount { get; set; }
    }
}
