﻿using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;
using vetFoodShop.IdentityServer.Dtos;
using vetFoodShop.IdentityServer.Models;

namespace vetFoodShop.IdentityServer.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class RegistersController : ControllerBase
    {
        private readonly UserManager<ApplicationUser> _userManager;

        public RegistersController(UserManager<ApplicationUser> userManager)
        {
            _userManager = userManager;
        }

        [HttpPost]
        public async Task<IActionResult> UserRegister(UserRegisterDto userRegisterDto)
        {
            var values = new ApplicationUser()
            {
                UserName = userRegisterDto.UserName,
                Email = userRegisterDto.Email,
                Name = userRegisterDto.Name,
                Surname = userRegisterDto.Surname,
            };
            var result = await _userManager.CreateAsync(values, userRegisterDto.Password);
            if (result.Succeeded)
            {
                return Ok("Kullanici basariyla eklendi.");
            }
            else
            {
                return Ok("Bir hata olustu tekrar deneyiniz.");
            }
        }
    }
}
