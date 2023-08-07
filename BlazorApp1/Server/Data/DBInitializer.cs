using BlazorApp1.Shared.Models;

namespace BlazorApp1.Server.Data
{
    public class DBInitializer
    {
        public static void Initialize(ApplicationDBContext context)
        {
            context.Database.EnsureCreated();

            if (!context.TodoItems.Any())
            {
                context.TodoItems.Add(new TodoItem { Title = "Задача 1", IsDone = false, AddedTime = DateTime.Now });
                context.TodoItems.Add(new TodoItem { Title = "Задача 2",  IsDone = true, Description = "Я сделал", AddedTime = DateTime.Now, CompletionTime = DateTime.Now.AddMonths(1) });
                context.TodoItems.Add(new TodoItem { Title = "Задача 3", IsDone = false, AddedTime = DateTime.Now });
                context.SaveChanges();
            }
        }
    }
}
