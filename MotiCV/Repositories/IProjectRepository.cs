using Domain.Entities;
using Repositories.Common;

namespace Repositories
{
    public interface IProjectRepository : IAsyncRepository<Project>
    {
    }
}
