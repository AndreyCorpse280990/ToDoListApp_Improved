using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ToDoListApp_Improved.Tasks
{
    // InMemoryToDoTaskStorage - хранилище задач, реализованное на ОЗУ
    public class InMemoryToDoTaskStorage : IToDoTaskStorage
    {
        private List<ToDoTask> _tasks;

        public InMemoryToDoTaskStorage() {
            _tasks = new List<ToDoTask>();
        }

        public void Add(ToDoTask task)
        {
            // 1. проверим существование такого же заголовка
            foreach (ToDoTask t in _tasks)
            {
                if (t.Title == task.Title)
                {
                    throw new InvalidOperationException("same titles are detected");
                }
            }
            // 2. если все ок, то добавили
            _tasks.Add(task.Clone() as ToDoTask);
        }

        public List<ToDoTask> ListAll()
        {
            List<ToDoTask> tasks = new List<ToDoTask>();
            foreach (ToDoTask t in _tasks)
            {
                tasks.Add(t.Clone() as ToDoTask);
            }
            return tasks;
        }

        public ToDoTask RemoveByTitle(string taskTitle)
        {
            ToDoTask foundTask = _tasks.FirstOrDefault(t => t.Title == taskTitle);
            if (foundTask != null)
            {
                _tasks.Remove(foundTask);
            }
            
            return foundTask;
        }

        public ToDoTask UpdateByTitle(string taskTitle, ToDoTask task)
        {
            ToDoTask foundTask = _tasks.FirstOrDefault(t => t.Title == taskTitle);
            if(foundTask != null)
            {
                // Обновляю поля найденной задачи
                foundTask.Title = task.Title;
                foundTask.Description = task.Description;
                foundTask.Priority = task.Priority;
                foundTask.IsCompleted = task.IsCompleted;
            }
            return foundTask;
        }
    }
}
