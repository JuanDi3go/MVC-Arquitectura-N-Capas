using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProyectoCrud.DAL.Repositorie
{
    public interface IGenericRepository<TEntityModel> where TEntityModel : class
    {
        Task<bool> Insert(TEntityModel entity);
        Task<bool> Update(TEntityModel entity);
        Task<bool> Delete(int id);
        Task<TEntityModel> GetById(int id);
        Task<IQueryable<TEntityModel>> GetAll();
    }
}
