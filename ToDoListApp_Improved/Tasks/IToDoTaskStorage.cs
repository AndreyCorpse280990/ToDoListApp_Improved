using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ToDoListApp_Improved.Tasks
{
    // IToDoTaskStorage - интерфейс, обеспечивающий операции работы с задачами в приложении
    public interface IToDoTaskStorage
    {
        // ListAll - получить список всех задач
        // вход: -
        // выход: список задач для выполнения
        List<ToDoTask> ListAll();

        // Add - добавить новую задачу, при добавлении задачии запрещается дублирование значений title
        // вход: добавляемая задача
        // выход: -
        void Add(ToDoTask task);

        // Remove - удалить задачу
        // вход: taskTitle - заголовок удаляемой задачи
        // выход: объект удаленной задачи или null
        ToDoTask RemoveByTitle(string taskTitle);

        // UpdateByTitle - обновить задачу по заголовку, поля переданного объекта сохраняются в обновляемую задачу
        // вход: taskTitle - заголовок существующей в хранилище задачи, task - новые данные для данной задачи
        // выход: объект обновленной записи или null
        ToDoTask UpdateByTitle(string taskTitle, ToDoTask task);
    }
}
