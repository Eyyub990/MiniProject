using Microsoft.EntityFrameworkCore;
using Repositories;
using Services.SkillGroup;

namespace Services.Implementation
{
    public class SkillGroupService(ISkillGroupRepository skillGroupRepository) : ISkillGroupService
    {
        public async Task<IEnumerable<SkillGroupGetAll>> GetAllAsync(CancellationToken cancellationToken = default)
        {
            return await skillGroupRepository.GetAll()
                .Select(m => new SkillGroupGetAll
                {
                    Id = m.Id,
                    Name = m.Name,
                    TypeId = m.TypeId,
                })
                .ToListAsync();
        }
    }
}
