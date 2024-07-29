namespace Services.Services
{
    public interface IServiceService
    {
        Task<IEnumerable<ServiceGetAll>> GetAllAsync(CancellationToken cancellationToken=default);
    }
}
