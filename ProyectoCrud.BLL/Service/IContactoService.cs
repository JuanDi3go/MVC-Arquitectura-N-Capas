using ProyectoCrud.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProyectoCrud.BLL.Service
{
    public interface IContactoService
    {
        Task<bool> Insert(Contacto entity);
        Task<bool> Update(Contacto entity);
        Task<bool> Delete(int id);
        Task<Contacto> GetById(int id);
        Task<IQueryable<Contacto>> GetAll();
        Task<Contacto> GetByName(string name);
    }
}
