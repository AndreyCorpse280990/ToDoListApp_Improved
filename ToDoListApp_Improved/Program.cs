using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;
using ToDoListApp_Improved.Tasks;
using ToDoListApp_Improved.UI;

namespace ToDoListApp_Improved
{
    internal static class Program
    {
        /// <summary>
        /// Главная точка входа для приложения.
        /// </summary>
        [STAThread]
        static void Main()
        {
            //
            IToDoTaskStorage taskStorage = new InMemoryToDoTaskStorage();
            taskStorage.Add(new ToDoTask() { Title = "task#1", Description = "task#1", Priority = 3, IsCompleted = false });
            taskStorage.Add(new ToDoTask() { Title = "task#2", Description = "task#2", Priority = 5, IsCompleted = true });
            taskStorage.Add(new ToDoTask() { Title = "task#3", Description = "task#3", Priority = 1, IsCompleted = false });
            //
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            Application.Run(new MainForm(taskStorage));
        }
    }
}
