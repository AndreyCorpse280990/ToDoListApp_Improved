using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using ToDoListApp_Improved.Tasks;
using ToDoListApp_Improved.UI.Views;

namespace ToDoListApp_Improved.UI
{
    public partial class MainForm : Form
    {
        private readonly IToDoTaskStorage _storage;
        public MainForm(IToDoTaskStorage taskStorage)
        {
            InitializeComponent();
            _storage = taskStorage;
            ViewToDoTaskList();
        }

        // хэлпер заполнения списка дел
        private void ViewToDoTaskList()
        {
            // 0. очистить старые данные
            toDoTaskListBox.Items.Clear();
            // 1. получаем список дел
            List<ToDoTask> tasks = _storage.ListAll();
            // 2. записываем задачи в список
            for (int i = 0; i < tasks.Count; i++)
            {
                toDoTaskListBox.Items.Add(new ToDoTaskListView(i+1, tasks[i]));
            }
        }

        private void addButton_Click(object sender, EventArgs e)
        {
            try
            {
                Hide();
                // 1. Создать экземпляр этой формы
                ToDoTaskForm toDoTaskForm = new ToDoTaskForm();
                // 2. Открыть
                toDoTaskForm.ShowDialog();
                // 3. Считать из объекта формы заполненный объект
                if (toDoTaskForm.ToDoTask != null)
                {
                    _storage.Add(toDoTaskForm.ToDoTask);
                    ViewToDoTaskList();
                }
                else
                {
                    MessageBox.Show("error");
                }
            }
            catch
            {
                // TODO: process exception
            }
            finally
            {
                Show();
            }
        }

        private void deleteButton_Click(object sender, EventArgs e)
        {           
            if (toDoTaskListBox.SelectedItem != null)
            {
                ToDoTaskListView selectedTaskView = (ToDoTaskListView)toDoTaskListBox.SelectedItem;

                string taskTitle = selectedTaskView.ToDoTask.Title;

                try
                {
                    _storage.RemoveByTitle(taskTitle);
                    ViewToDoTaskList();
                }
                catch (Exception ex)
                {
                    MessageBox.Show($"Ошибка при удалении задачи: {ex.Message}");
                }
            }
            else
            {
                MessageBox.Show("Выберите задачу для удаления.");
            }
        }
    }
}
