namespace TodoListAPI.Services
{
    public class TodoService : ITodoService
    {
        //TodoLists from Data.DataContext and TodoList from Models

        private readonly DataContext _context;
        public TodoService(DataContext Context)
        {
            _context = Context;
        }

        public async Task<List<TodoList>> GetTodoList()
        {
            var list = await _context.TodoLists.ToArrayAsync();
            return list.Select(a => new TodoList()
            {
                Id = a.Id,
                Tlist = a.Tlist,
                IsComplete = a.IsComplete,
                DateAdd = a.DateAdd,
                DueDate = a.DueDate

            }).ToList();
        }
        public async Task<TodoList> GetTodoList(int id)
        {
            var todoList = await _context.TodoLists.FindAsync(id);
            if (todoList == null)
            {
                return null;
            }

            return new TodoList() {
                Id = todoList.Id,
                Tlist = todoList.Tlist,
                IsComplete = todoList.IsComplete,
                DateAdd = todoList.DateAdd,
                DueDate = todoList.DueDate
            };
        }
        public async Task<TodoList> CreateList(TodoList newTodo)
        {
            var todo = new TodoList()
            {
                Tlist = newTodo.Tlist,
                IsComplete = newTodo.IsComplete,
                DateAdd = newTodo.DateAdd,
                DueDate = newTodo.DueDate
            };
            try
            {
                _context.Add(todo);
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException err)
            {
                throw err;
            }
            return newTodo;
        }

        public async Task<TodoList> UpdateList(int id, TodoList newTodo)
        {
            var todo = _context.TodoLists.First(a => a.Id == id);
            todo.Id = id;
            todo.Tlist = newTodo.Tlist;
            todo.IsComplete = newTodo.IsComplete;
            todo.DateAdd = newTodo.DateAdd;
            todo.DueDate = newTodo.DueDate;
            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException err)
            {
                throw err;
            }
            return newTodo;
        }

        public async Task<TodoList> DeleteList(int id)
        {
            var todo = _context.TodoLists.Find(id);
            try
            {
                _context.Remove(todo);
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException err)
            {
                throw err;
            }
            return new TodoList()
            {
                Id = todo.Id,
                Tlist = todo.Tlist,
                IsComplete = todo.IsComplete,
                DateAdd = todo.DateAdd,
                DueDate = todo.DueDate
            };
        }






    }
}
