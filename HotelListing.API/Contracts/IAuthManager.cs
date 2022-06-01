﻿using HotelListing.API.Dto.User;
using Microsoft.AspNetCore.Identity;

namespace HotelListing.API.Contracts
{
    public interface IAuthManager
    {
        public Task<IEnumerable<IdentityError>> Register(ApiUserDto userDto);
        public Task<AuthResponseDto> Login(ApiUserLoginDto userLoginDto);
    }
}
