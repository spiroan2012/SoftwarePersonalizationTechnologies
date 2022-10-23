namespace Intefaces.Services
{
    public interface IHealthCheckService
    {
        Task<string> DatabaseHealthCheck();
        Task<string> ApiHealthCheck();
    }
}
