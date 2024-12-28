using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using vetFoodShop.Cargo.BusinessLayer.Abstract;
using vetFoodShop.Cargo.DataAccessLayer.Abstract;
using vetFoodShop.Cargo.EntityLayer.Concrete;

namespace vetFoodShop.Cargo.BusinessLayer.Concrete
{
    public class CargoDetailManager : ICargoDetailService
    {
        private readonly ICargoDetailDal _cargoDetailDal;

        public CargoDetailManager(ICargoDetailDal cargoDetailDal)
        {
            _cargoDetailDal = cargoDetailDal;
        }

        public void TDelete(int id)     
        {
            _cargoDetailDal.Delete(id);
        }

        public List<CargoDetail> TGetAll()  // (GetAll) başında T olan methodlar business katmanından [bunları API'dan çağıracağız]
        {
            return _cargoDetailDal.GetAll();    // (GetAll) dataaccess'den tanımlı olan methodlar
        }

        public CargoDetail TGetById(int id)
        {
            return _cargoDetailDal.GetById(id);
        }

        public void TInsert(CargoDetail entity)
        {
            _cargoDetailDal.Insert(entity);
        }

        public void TUpdate(CargoDetail entity)
        {
            _cargoDetailDal.Update(entity);
        }
    }
}
