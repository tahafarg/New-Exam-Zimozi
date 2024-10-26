using model;

namespace ModelRepo.GenralRepo
{
    public interface IGenralRepo<T> where T : BaseEntity
    {
        Task<List<T>> GetAll();
        Task<T> Get(Guid id);
        Task<bool> Insert(T entity);
        Task<bool> Update(T entity);
        Task<bool> Delete(Guid id);
        //bool Remove(T entity);
        Task SaveChanges();

    }
}
