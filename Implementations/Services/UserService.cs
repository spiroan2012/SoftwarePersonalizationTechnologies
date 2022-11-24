using AutoMapper;
using Dtos.Requests;
using Dtos.Responses;
using Intefaces.Repositories;
using Microsoft.Extensions.Caching.Memory;
using Models;
using Models.Params;
using PagedListForEFCore;
using Polly;
using Polly.CircuitBreaker;
using Polly.Retry;

namespace Intefaces.Services
{
    public class UserService : IUserService
    {
        private readonly IUserRepository _userRepository;
        private readonly IGenreRepository _genreRepository;
        private readonly IMapper _mapper;
        private readonly AsyncRetryPolicy _retryPolicy;
        private readonly AsyncCircuitBreakerPolicy _circuitBreakerPolicy;
        private readonly IMemoryCache _memoryCache;
        public UserService(IUserRepository userRepository, IGenreRepository genreRepository,IMapper mapper, IMemoryCache memoryCache)
        {
            _userRepository = userRepository;
            _genreRepository = genreRepository;
            _mapper = mapper;
            _retryPolicy = Policy.Handle<Exception>().RetryForeverAsync();
            _circuitBreakerPolicy = Policy.Handle<Exception>(result => string.IsNullOrEmpty(result.Message)).CircuitBreakerAsync(2, TimeSpan.FromSeconds(1));
            _memoryCache = memoryCache;
        }

        public async Task<IList<UserDto>> GetById(string id)
        {
            var response = await _circuitBreakerPolicy.ExecuteAsync(() => _retryPolicy.ExecuteAsync(async () =>
            {
                var user = await _userRepository.GetUserByIdAsync(int.Parse(id));
                if (user == null) throw new Exception("not found");
                var userList = _mapper.Map<List<UserDto>>(user);
                return userList;
            }));
            return response;
        }

        public async Task<IList<UserDto>> GetByUsername(string username)
        {
            var user = await _userRepository.GetUserByUsernameAsync(username);
            if (user == null) throw new Exception("not found");
            return _mapper.Map<List<UserDto>>(user);
        }

        public async Task<IList<GenreDto>> GetGenresForUser(int userId)
        {
            var genres = await _userRepository.GetGenresForUser(userId);
            return _mapper.Map<List<GenreDto>>(genres);
        }

        public async Task<Tuple<IList<UserDto>, PagedListHeaders>> GetUsers(UserParams userParams)
        {
            PagedListHeaders header = new();
            var response = await _circuitBreakerPolicy.ExecuteAsync(() => _retryPolicy.ExecuteAsync(async () =>
            {
                IList<UserDto> usersList = new List<UserDto>();
                //if (!_memoryCache.TryGetValue($"{userParams}", out IList<UserDto> usersList))
                //{
                    var users = await _userRepository.GetUsersAsync(userParams);
                    header = PagedList<AppUser>.ToHeader(users);
                    usersList = _mapper.Map<List<UserDto>>(users);
                   // _memoryCache.Set($"{userParams}", usersList, new TimeSpan(0, 5, 0));
               // }
                return new Tuple<IList<UserDto>, PagedListHeaders>(usersList, header);
            }));
            return response;
            /*var users = await _userRepository.GetUsersAsync(userParams);
            var header = PagedList<AppUser>.ToHeader(users);
            return new Tuple<IList<UserDto>, PagedListHeaders> (_mapper.Map<List<UserDto>>(users), header);*/
        }

        public async Task UpdateGenresForLoggedUser(int[] genreIds, int userId)
        {
            List<Genre> genres = new List<Genre>();
            foreach(int genreId in genreIds)
            {
                Genre genre = await _genreRepository.GetGenreByIdAsync(genreId);

                if(genre == null)
                {
                    throw new Exception($"The genre with id {genreId} was not found");
                }
                genres.Add(genre); 
            }
            var user = await _userRepository.GetUserByIdAsync(userId);
            if (user == null) throw new Exception("User not found");

            _userRepository.RemoveGenresForUser(user);

            foreach (var genre in genres)
            {
                _userRepository.AddGenreForUser(genre, user);
            }
            var isComplete = await _userRepository.Complete();
            if (!isComplete) throw new Exception($"Failed to update logged user location");
        }

        public async Task UpdateUserLocation(string userId, LocationDto locationDto)
        {
            var userTochange = await _userRepository.GetUserByIdAsync(int.Parse(userId));

            _userRepository.UpdateUserLocationAsync(userTochange, locationDto.Longitude, locationDto.Latitude);
            var isComplete = await _userRepository.Complete();
            if (!isComplete) throw new Exception($"Failed to update logged user location");
        }
    }
}
