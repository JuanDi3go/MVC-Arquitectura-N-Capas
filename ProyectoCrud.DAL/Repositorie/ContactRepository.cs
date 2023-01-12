using ProyectoCrud.DAL.DataContext;
using ProyectoCrud.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProyectoCrud.DAL.Repositorie
{
    public class ContactRepository : IGenericRepository<Contacto>
    {
        private readonly CeArquitecturaNcapasContext _dbContext;

        public ContactRepository(CeArquitecturaNcapasContext dbContext)
        {
            _dbContext = dbContext;
        }
        public async Task<bool> Insert(Contacto entity)
        {
         await  _dbContext.Contactos.AddAsync(entity);
            await _dbContext.SaveChangesAsync();  
            return true;
        }

        public async Task<bool> Update(Contacto entity)
        {
            _dbContext.Update(entity);
            await _dbContext.SaveChangesAsync();

            return true;
        }

        public async Task<bool> Delete(int id)
        {
            Contacto model = _dbContext.Contactos.First(c => c.IdContacto == id);
            _dbContext.Contactos.Remove(model);
            await _dbContext.SaveChangesAsync();
            return true;
        }

        public async Task<IQueryable<Contacto>> GetAll()
        {
            IQueryable<Contacto> queryContactoSQL = _dbContext.Contactos;
            return queryContactoSQL;
        }

        public async Task<Contacto> GetById(int id)
        {
            return await _dbContext.Contactos.FindAsync(id);
        }

      
    }
}
