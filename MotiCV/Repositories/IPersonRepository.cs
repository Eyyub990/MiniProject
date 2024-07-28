using Domain.Entities;
using Repositories.Common;

namespace Repositories
{
    public interface IPersonRepository : IAsyncRepository<Person>
    {
    }
}
