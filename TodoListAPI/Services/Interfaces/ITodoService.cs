namespace TodoListAPI.Services.Interfaces
{
    public interface ITodoService
    {
        public Task<List<TodoList>> GetTodoList();
        public Task<TodoList> GetTodoList(int id);
        public Task<TodoList> CreateList(TodoList contract);
        public Task<TodoList> UpdateList(int id, TodoList contract);
        public Task<TodoList> DeleteList(int id);
    }
}
