using Domain.Entities;
using Repositories.Common;

namespace Repositories
{
    public interface IServiceRepository : IAsyncRepository<Service>
    {
    }
}
