using Microsoft.EntityFrameworkCore;
using model;
using ModelRepo.Context;

namespace ModelRepo.GenralRepo
{
    public class GenralRepo<T>:IGenralRepo<T> where T : BaseEntity
    {

        private readonly AppDbContext context;
        private DbSet<T> entities;
        string errorMessage = string.Empty;

        public GenralRepo(AppDbContext context)
        {
            this.context = context;
            entities = context.Set<T>();
        }
        public async Task<List<T>> GetAll()
        {
            return await entities.ToListAsync();
        }

        public async Task<T> Get(Guid id)
        {
            return await entities.FindAsync(id);
        }
        public async Task<bool> Insert(T entity)
        {
            if (entity == null)
            {
                throw new ArgumentNullException("entity");
            }
            await entities.AddAsync(entity);
            await SaveChanges();
            return true;
        }

        public async Task<bool> Update(T entity)
        {
            if (entity == null)
            {
                throw new ArgumentNullException("entity");
            }
            
            entities.Update(entity);
            await SaveChanges();

            return true;
        }

        public async Task<bool> Delete(Guid id)
        {
            var employee = await entities.FindAsync(id);
            if (employee != null)
            {
                entities.Remove(employee);
                await SaveChanges();
                return true;
            }
            return false;
        }
        
        public async Task SaveChanges()
        {
            await context.SaveChangesAsync();
        }
    }
}
