using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TryParseBatikan
{
    internal class ToDoService
    {
        //private readonly static List<ToDoItem> tasks = new List<ToDoItem>();
        //private static int nextId = 1; //tiq moje i da go istriem no gi zakomentirah 

        private readonly ToDoStorage storage;
        private readonly FileStorage fileStorage;

        public ToDoService(FileStorage file)
        {
            fileStorage = file;
            this.storage = fileStorage.Load();
        }

        public IReadOnlyList<ToDoItem> GetAll()
        {
            return storage.Todos;
        }
        public ToDoItem FindById(int id)
        {
            ToDoItem targetTodo = null;
            foreach (ToDoItem todoItem in storage.Todos)
            {
                if (todoItem.Id == id)
                {
                    return todoItem;
                }

            }

            return null;
        }

        public void Add(string title, string description, DateTime dueTime)
        {
            ToDoItem todoItem = new ToDoItem(storage.NextId, title, description, dueTime);
            storage.Todos.Add(todoItem);
            storage.NextId++;

            fileStorage.Save(storage);
        }

        public void Complete(int id)
        {
            ToDoItem completedTask = FindById(id);
            if (completedTask == null)
                throw new ArgumentException("Няма такава задаа с такова ID ");

            completedTask.Completed();

            fileStorage.Save(storage);

        }


        public void Delete(int id)
        {
             ToDoItem deleteTask = FindById(id);
            if (deleteTask == null)
                throw new ArgumentException("Няма такава задаа с такова ID ");

             storage.Todos.Remove(deleteTask);
             fileStorage.Save(storage);
        }
    }
}
