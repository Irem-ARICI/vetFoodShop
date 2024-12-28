using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using vetFoodShop.Cargo.BusinessLayer.Abstract;
using vetFoodShop.Cargo.DtoLayer.Dtos.CargoCompanyDtos;
using vetFoodShop.Cargo.DtoLayer.Dtos.CargoDetailDtos;
using vetFoodShop.Cargo.EntityLayer.Concrete;

namespace vetFoodShop.Cargo.WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CargoDetailsController : ControllerBase
    {
        private readonly ICargoDetailService _cargoDetailService;

        public CargoDetailsController(ICargoDetailService cargoDetailService)
        {
            _cargoDetailService = cargoDetailService;
        }

        [HttpGet]
        public IActionResult CargoDetailList()
        {
            var values = _cargoDetailService.TGetAll();
            return Ok(values);
        }

        [HttpPost]
        public IActionResult CreateCargoDetail(CreateCargoDetailDto createCargoDetailDto)
        {
            CargoDetail cargoDetail = new CargoDetail()
            {
                Barcode = createCargoDetailDto.Barcode,
                CargoCompanyId = createCargoDetailDto.CargoCompanyId,
                ReceiverCustomer = createCargoDetailDto.ReceiverCustomer,
                SenderCustomerId = createCargoDetailDto.SenderCustomerId
               
            };
            _cargoDetailService.TInsert(cargoDetail);
            return Ok("Kargo detayları başarıyla oluşturuldu");
        }

        [HttpDelete]
        public IActionResult DeleteCargoDetail(int id)
        {
            _cargoDetailService.TDelete(id);
            return Ok("Kargo detayları başarıyla silindi.");
        }

        [HttpGet("{id}")]
        public IActionResult GetCargoDetail(int id)
        {
            var values = _cargoDetailService.TGetById(id);
            return Ok(values);
        }

        [HttpPut]
        public IActionResult UpdateCargoDetail(UpdateCargoDetailDto updateCargoDetailDto)
        {
            CargoDetail cargoDetail = new CargoDetail()
            {
                Barcode=updateCargoDetailDto.Barcode,
                CargoCompanyId = updateCargoDetailDto.CargoCompanyId,
                CargoDetailId = updateCargoDetailDto.CargoDetailId,
                ReceiverCustomer=updateCargoDetailDto.ReceiverCustomer,
                SenderCustomerId = updateCargoDetailDto.SenderCustomerId
            };
            return Ok("Kargo detayları başarıyla güncellendi.");
        }
    }
}
