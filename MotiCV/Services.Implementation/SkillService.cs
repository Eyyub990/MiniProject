using Microsoft.EntityFrameworkCore;
using Repositories;
using Services.Skills;

namespace Services.Implementation
{
    public class SkillService : ISkillService
    {
        private readonly ISkillRepository skillRepository;

        public SkillService(ISkillRepository skillRepository)
        {
            this.skillRepository = skillRepository;
        }
        public async Task<IEnumerable<SkillGetAll>> GetAllAsync(CancellationToken cancellationToken = default)
        {
            return await skillRepository.GetAll()
                .Select(x => new SkillGetAll
                {
                    Id = x.Id,
                    Name = x.Name,
                    GroupId = x.GroupId
                })
                .ToListAsync();
        }
    }
}
