using ExampleJWT.BLL.Abstract;
using ExampleJWT.Models;
using ExampleJWT.TokenHandler;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ExampleJWT.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class LoginController : ControllerBase
    {
        readonly IUserService _userService;
        readonly IConfiguration _configuration;

        public LoginController(IUserService userService, IConfiguration configuration)
        {
            _userService = userService;
            _configuration = configuration;
        }

        [HttpPost("[action]")]
        public async Task<bool> Create([FromForm] User user)
        {
           return await _userService.AddAsync(user);
           
        }

        [HttpPost("[action]")]
        public async Task<Token> Login([FromForm] UserLogin userLogin)
        {
            //User user = await _context.Users.FirstOrDefaultAsync(x => x.Email == userLogin.Email && x.Password == userLogin.Password);
            User user = await _userService.GetSingleNameMailAsync(userLogin);
            if (user != null)
            {
                //Token üretiliyor.
                TokenHandlerCs tokenHandler = new TokenHandlerCs(_configuration);
                Token token = tokenHandler.CreateAccessToken(user);

                //Refresh token Users tablosuna işleniyor.
                user.RefreshToken = token.RefreshToken;
                user.RefreshTokenEndDate = token.Expiration.AddMinutes(3);
                await _userService.Update(user);

                return token;
            }
            return null;
        }

        [HttpGet("[action]")]
        public async Task<Token> RefreshTokenLogin([FromForm] string refreshToken)
        {
            User user = await _userService.GetSingleByRefreshTokenAsync(refreshToken);
            if (user != null && user?.RefreshTokenEndDate > DateTime.Now)
            {
                TokenHandlerCs tokenHandler = new TokenHandlerCs(_configuration);
                Token token = tokenHandler.CreateAccessToken(user);

                user.RefreshToken = token.RefreshToken;
                user.RefreshTokenEndDate = token.Expiration.AddMinutes(3);
                await _userService.Update(user);

                return token;
            }
            return null;
        }
    }
}
