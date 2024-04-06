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

namespace ToDoListApp_Improved.UI
{
    public partial class ToDoTaskForm : Form
    {
        private ToDoTask toDoTask;

        public ToDoTask ToDoTask { get { return toDoTask; } }

        public ToDoTaskForm()
        {
            InitializeComponent();
            toDoTask = null;
            priorityComboBox.SelectedIndex = 0;
        }

        private void cancelButton_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void saveButton_Click(object sender, EventArgs e)
        {
            // все введенные данные считываются в объект
            toDoTask = new ToDoTask()
            {
                Title = titleTextBox.Text,
                Description = descriptionTextBox.Text,
                Priority = Convert.ToInt32(priorityComboBox.Text),
                IsCompleted = isCompletedCheckBox.Checked
            };
            Close();
        }
    }
}
