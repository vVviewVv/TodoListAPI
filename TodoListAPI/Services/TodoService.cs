using TodoListAPI.Models;

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
                DueDate = a.DueDate,
                SubLists = a.SubLists



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
                DueDate = todoList.DueDate,
                SubLists = todoList.SubLists
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
            var todoList = await _context.TodoLists.FindAsync(id);
            if (todoList == null)
            {
                return null;
            }
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
            if (todo == null)
            {
                return null;
            }
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

        public async Task<TodoSubList> GetTodoSubList(int id_sub, int id_list)
        {
            var todoList = await _context.TodoLists.FindAsync(id_list);
            var todoSubList = await _context.TodoSubLists.FindAsync(id_sub);
            if (todoList == null)
            {
                return null;

            }else if(todoSubList == null)
            {
                return null;
            }
            else if(todoSubList.Id_list != id_list)
            {
                return null;
            }
            return new TodoSubList() {
                Id = todoSubList.Id,
                Slist = todoSubList.Slist,
                IsComplete = todoSubList.IsComplete,
                Id_list = todoSubList.Id_list
            };

        }

        public async Task<TodoSubList> CreateSubList(int id_list, TodoSubList newTodoSub)
        {
            var todoList = await _context.TodoLists.FindAsync(id_list);
            if (todoList == null)
            {
                return null;

            }
            var SubList = new TodoSubList()
            {
                //Id = newTodoSub.Id,
                Slist = newTodoSub.Slist,
                IsComplete = newTodoSub.IsComplete,
                Id_list = id_list
            };
            try
            {
                _context.Add(SubList);
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException err)
            {
                throw err;
            }
            return newTodoSub;
        }

        public async Task<TodoSubList> UpdateSubList(int id_sub, int id_list, TodoSubList newTodoSub)
        {
            var todoList = await _context.TodoLists.FindAsync(id_list);
            var todoSubList = await _context.TodoSubLists.FindAsync(id_sub);
            if (todoList == null)
            {
                return null;

            }
            else if (todoSubList == null)
            {
                return null;
            }
            else if (todoSubList.Id_list != id_list)
            {
                return null;
            }
            var todo = _context.TodoSubLists.First(a => a.Id == id_sub);
            todo.Id = id_sub;
            todo.Slist = newTodoSub.Slist;
            todo.IsComplete = newTodoSub.IsComplete;
            todo.Id_list = id_list;
            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException err)
            {
                throw err;
            }
            return newTodoSub;

        }

        public async Task<TodoSubList> DeleteSubList(int id_sub, int id_list)
        {
            var todoList = await _context.TodoLists.FindAsync(id_list);
            var todoSubList = await _context.TodoSubLists.FindAsync(id_sub);
            if (todoList == null)
            {
                return null;

            }
            else if (todoSubList == null)
            {
                return null;
            }
            else if (todoSubList.Id_list != id_list)
            {
                return null;
            }

            var todo = _context.TodoSubLists.Find(id_sub);
            try
            {
                _context.Remove(todo);
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException err)
            {
                throw err;
            }
            return new TodoSubList()
            {
                Id = todo.Id,
                Slist = todo.Slist,
                IsComplete = todo.IsComplete,
                Id_list = id_list

            };
        }
    }
}
