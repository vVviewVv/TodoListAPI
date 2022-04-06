using TodoListAPI.Models;

namespace TodoListAPI.Services.Interfaces
{
    public interface ITodoService
    {
        public Task<List<TodoList>> GetTodoList();
        public Task<TodoList> GetTodoList(int id);
        public Task<TodoList> CreateList(TodoList contract);
        public Task<TodoList> UpdateList(int id, TodoList contract);
        public Task<TodoList> DeleteList(int id);



        public Task<TodoSubList> GetTodoSubList(int id, int ids);
        public Task<TodoSubList> CreateSubList(int id, TodoSubList contract);
        public Task<TodoSubList> UpdateSubList(int id, int ids, TodoSubList contract);
        public Task<TodoSubList> DeleteSubList(int id, int ids);
    }
}
