using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace vetFoodShop.Cargo.BusinessLayer.Abstract
{
    public interface IGenericService<T> where T : class
    {
        // başında T olnalar Business'dan gelcek, olmayanlar accsessden katmanından gelen methodlar olmuş olcak 
        void TInsert(T entity);
        void TUpdate(T entity);
        void TDelete(int id);
        T TGetById(int id);
        List<T> TGetAll();
    }
}
