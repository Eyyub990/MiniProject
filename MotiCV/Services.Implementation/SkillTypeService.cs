using Microsoft.EntityFrameworkCore;
using Repositories;
using Services.SkillType;

namespace Services.Implementation
{
    public class SkillTypeService(ISkillTypeRepository skillTypeRepository) : ISkillTypeService
    {
        public async Task<IEnumerable<SkillTypeGetAll>> GetAllAsync(CancellationToken cancellationToken = default)
        {
            return await skillTypeRepository.GetAll()
                .Select(m => new SkillTypeGetAll
                {
                    Id = m.Id,
                    Name = m.Name
                })
                .ToListAsync();
        }
    }
}
