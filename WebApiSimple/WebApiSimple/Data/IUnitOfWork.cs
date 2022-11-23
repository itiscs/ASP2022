using WebApiSimple.Models;

namespace WebApiSimple.Data
{
    public interface IUnitOfWork
    {
        IRepository<TodoItem> todoRepository { get; set; }
        void SaveChanges();
    }
}
