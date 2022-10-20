using Microsoft.EntityFrameworkCore;
using WebApiSimple.Models;

namespace WebApiSimple.Data
{
    public class TodoItemRepository : IRepository<TodoItem>
    {
        private TodoContext _db;
        public TodoItemRepository(TodoContext db)
        {
            _db = db;
        }

        public  void Add(TodoItem entity)
        {
            
            _db.Add(entity);
            _db.SaveChanges();
        }

        public void Delete(long id)
        {
            var item = Get(id);
            if(item != null)    
                _db.TodoItems.Remove(item);
            _db.SaveChanges();

        }

        public TodoItem Get(long id)
        {
            return _db.TodoItems.Find(id);
        }

        public IEnumerable<TodoItem> GetAll()
        {
            return _db.TodoItems.ToList();
        }

        public void Update(TodoItem entity)
        {
            _db.Entry(entity).State = EntityState.Modified;
            _db.SaveChanges();
        }
    }
}
