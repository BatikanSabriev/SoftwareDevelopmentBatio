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
        private readonly static List<ToDoItem> tasks = new List<ToDoItem>();
        private static int nextId = 1;

        public List<ToDoItem> GetAll()
        {
            return tasks;
        }
        public ToDoItem FindById(int id)
        {
            ToDoItem targetTodo = null;
            foreach (ToDoItem todoItem in tasks)
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
            ToDoItem todoItem = new ToDoItem(nextId, title, description, dueTime);
            tasks.Add(todoItem);
            nextId++; 
        }

        public void Complete(int id)
        {
            ToDoItem completedTask = FindById(id);
            if (completedTask == null)
                throw new ArgumentException("Няма такава задаа с такова ID ");

            completedTask.Completed();

        }


        public void Delete(int id)
        {
             ToDoItem deleteTask = FindById(id);
            if (deleteTask == null)
                throw new ArgumentException("Няма такава задаа с такова ID ");
             tasks.Remove(deleteTask);
        }




    }
}
