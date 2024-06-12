using PromoCodeFactory.Core.Abstractions;
using PromoCodeFactory.Core.Abstractions.Repositories;
using PromoCodeFactory.Core.Domain;
using PromoCodeFactory.Core.Domain.Administration;
using PromoCodeFactory.WebHost.Models.Abstractions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PromoCodeFactory.WebHost.Models.Abstraction
{
    public interface ITransfer<T, P>
        where T : ModelRequest
        where P : ModelResponse
    {
        public Task<Guid> SendCreate(T entity);
        public Task<P> SendGet(Guid id);
        public Task<IEnumerable<P>> SendGetList();
        public Task<P> SendUpdate(Guid id, T entity);
        public Task SendDelete(Guid id);
    }
}
