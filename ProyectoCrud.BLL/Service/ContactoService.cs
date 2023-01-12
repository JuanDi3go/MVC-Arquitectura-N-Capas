using ProyectoCrud.DAL.DataContext;
using ProyectoCrud.DAL.Repositorie;
using ProyectoCrud.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProyectoCrud.BLL.Service
{
    public class ContactoService : IContactoService
    {
       

        private readonly IGenericRepository<Contacto> _repositoryContacto ;

        public ContactoService(IGenericRepository<Contacto> repositoryContacto)
        {
            _repositoryContacto = repositoryContacto;
        }

        public async Task<bool> Delete(int id)
        {
          return  await _repositoryContacto.Delete(id);
        }

        public async Task<IQueryable<Contacto>> GetAll()
        {
            return await _repositoryContacto.GetAll();
        }

        public async Task<Contacto> GetById(int id)
        {
           return await _repositoryContacto.GetById(id);
        }

 

        public async Task<bool> Insert(Contacto entity)
        {
            return await _repositoryContacto.Insert(entity);
        }

        public async Task<bool> Update(Contacto entity)
        {
            return await _repositoryContacto.Update(entity);
        }

        public async Task<Contacto> GetByName(string name)
        {
            IQueryable<Contacto> queryContactoSql = await _repositoryContacto.GetAll();

            Contacto contact = queryContactoSql.Where(c => c.Nombre == name).FirstOrDefault();
            return contact;
        }

    }
}
