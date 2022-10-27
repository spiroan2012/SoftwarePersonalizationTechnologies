﻿using Dtos.Requests;
using Dtos.Responses;
using Implementations;
using Intefaces.Services;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Models.Params;
using System.Security.Claims;

namespace Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [Authorize]
    public class UsersController : ControllerBase
    {
        private readonly IUserService _userService;

        public UsersController(IUserService userService)
        {
            _userService = userService;
        }

        [HttpGet]
        public async Task<ActionResult<IList<UserDto>>> GetUsers([FromQuery] UserParams userParams)
        {
            var response = await _userService.GetUsers(userParams);
            Response.AddPaginationHeader(response.Item2.CurrentPage, response.Item2.PageSize, response.Item2.TotalCount, response.Item2.TotalPages);
            return Ok(response.Item1);
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<IList<UserDto>>> GetUserById(string id)
        {
            return Ok(await _userService.GetById(id));
        }

        [HttpGet("GetByUsername/{username}")]
        public async Task<ActionResult<IList<UserDto>>> GetUserByUsername(string username)
        {
            return Ok(await _userService.GetByUsername(username));
        }

        [HttpPatch("UpdateUserLocation")]
        public async Task<ActionResult> UpdateUserLocation(LocationDto locationDto)
        {
            string userId = User.FindFirst(ClaimTypes.NameIdentifier)?.Value;

            await _userService.UpdateUserLocation(userId, locationDto);

            return Ok();
        }


        //[HttpGet("GetByEmail/{email}")]
        //public async Task<ActionResult<IEnumerable<UserDto>>> GetUserByEmail(string email)
        //{
        //    var user = await _userRepository.GetUserByEmailAsync(email);
        //    if (user is null) return Ok(null);
        //    return Ok(_mapper.Map<UserDto>(user));
        //}
    }
}
