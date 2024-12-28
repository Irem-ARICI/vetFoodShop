using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using vetFoodShop.Cargo.DataAccessLayer.Abstract;
using vetFoodShop.Cargo.DataAccessLayer.Concrete;
using vetFoodShop.Cargo.DataAccessLayer.Repositories;
using vetFoodShop.Cargo.EntityLayer.Concrete;

namespace vetFoodShop.Cargo.DataAccessLayer.EntityFramework
{
    public class EfCargoCustomerDal : GenericRepository<CargoCustomer>, ICargoCustomerDal
    {
        public EfCargoCustomerDal(CargoContext context) : base(context)
        {
            
        }
    }
}
