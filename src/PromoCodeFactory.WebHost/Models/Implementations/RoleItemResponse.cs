using PromoCodeFactory.WebHost.Models.Abstractions;
using System;

namespace PromoCodeFactory.WebHost.Models.Implementations
{
    public class RoleItemResponse
    {
        public Guid Id { get; set; }

        public string Name { get; set; }

        public string Description { get; set; }
    }
}