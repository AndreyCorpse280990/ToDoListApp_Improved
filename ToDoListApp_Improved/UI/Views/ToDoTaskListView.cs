using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ToDoListApp_Improved.Tasks;

namespace ToDoListApp_Improved.UI.Views
{
    // ToDoTaskListView - класс, описывающий представление дела для отображение в списке
    internal class ToDoTaskListView
    {
        public int Number { get; set; }
        public ToDoTask ToDoTask { get; set; }

        public ToDoTaskListView(int number, ToDoTask toDoTask)
        {
            Number = number;
            ToDoTask = toDoTask;
        }

        public override string ToString()
        {
            return $"{Number}. {ToDoTask}";
        }
    }
}
