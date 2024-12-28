using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using vetFoodShop.Basket.Dtos;
using vetFoodShop.Basket.LoginServices;
using vetFoodShop.Basket.Services;

namespace vetFoodShop.Basket.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BasketsController : ControllerBase
    {
        private readonly IBasketService _basketService;
        private readonly ILoginService _loginService;
        public BasketsController(IBasketService basketService, ILoginService loginService)
        {
            _basketService = basketService;
            _loginService = loginService;
        }

        [HttpGet]
        public async Task<IActionResult> GetMyBasketDetail()
        {
            var user = User.Claims; //sisteme girmis ola token'in bilgilerini vercek (jwt.io'dakileri vs'da da gorebilmemizi saglar)
            var values = await _basketService.GetBasket(_loginService.GetUserId);
            return Ok(values);
        }

        [HttpPost]
        public async Task<IActionResult> SaveMyBasket(BasketTotalDto basketTotalDto)
        {
            basketTotalDto.UserId = _loginService.GetUserId;
            await _basketService.SaveBasket(basketTotalDto);
            return Ok("Sepetteki değişiklikler kaydedildi.");
        }


    }
}
