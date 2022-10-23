using Intefaces.Repositories;
using Polly;
using Polly.CircuitBreaker;
using Polly.Retry;

namespace Intefaces.Services
{
    public class HealthcheckService : IHealthCheckService
    {
        private readonly IUserRepository _userRepository;
        private readonly AsyncRetryPolicy _retryPolicy;
        private readonly AsyncCircuitBreakerPolicy _circuitBreakerPolicy;

        public HealthcheckService(IUserRepository userRepository)
        {
            _userRepository = userRepository;
            _retryPolicy = Policy.Handle<Exception>().RetryForeverAsync();
            _circuitBreakerPolicy = Policy.Handle<Exception>(result => string.IsNullOrEmpty(result.Message)).CircuitBreakerAsync(2, TimeSpan.FromSeconds(1));
        }

        public async Task<string> ApiHealthCheck()
        {
            var result = await Task.Run(() =>
            {
                return DateTime.Now.ToString();
            });
            return result;
        }

        public async Task<string> DatabaseHealthCheck()
        {
            var result = await _userRepository.HealthCheck();
            return result;
        }
    }
}
