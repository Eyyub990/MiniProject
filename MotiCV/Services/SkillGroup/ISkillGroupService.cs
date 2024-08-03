namespace Services.SkillGroup
{
    public interface ISkillGroupService
    {
        Task<IEnumerable<SkillGroupGetAll>> GetAllAsync(CancellationToken cancellationToken = default);

    }
}
