using Dtos.Responses;
using Intefaces;
using Models.Params;

namespace Implementations
{
    public class ShowCacheKey : ICacheKey<IList<ShowDto>>
    {
        private readonly ShowParams _showParams;
        public ShowCacheKey(ShowParams showParams)
        {
            _showParams = showParams;
        }
        public string CacheKey => $"Show_{_showParams}";
    }
}
