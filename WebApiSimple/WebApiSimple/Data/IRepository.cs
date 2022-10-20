namespace WebApiSimple.Data
{
    public interface IRepository<T> where T : class 
    {
        IEnumerable<T> GetAll();
        T Get(long id);
        void Add(T entity);
        void Update(T entity);
        void Delete(long id);

        
    }
}
