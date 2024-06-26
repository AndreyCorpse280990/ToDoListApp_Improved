﻿using System;
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
        public event EventHandler<ToDoTask> TaskUpdated; // событие для сохрания

        public ToDoTask ToDoTask { get { return toDoTask; } }

        public ToDoTaskForm()
        {
            InitializeComponent();
            toDoTask = new ToDoTask(); // Инициализация toDoTask
            priorityComboBox.SelectedIndex = 0;
        }


        // Конструктор для редактирования задачи
        public ToDoTaskForm(ToDoTask task) : this()
        {
            toDoTask = task;

            titleTextBox.Text = task.Title;
            descriptionTextBox.Text = task.Description;
            priorityComboBox.Text = task.Priority.ToString();
            isCompletedCheckBox.Checked = task.IsCompleted;
        }

        private void cancelButton_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void saveButton_Click(object sender, EventArgs e)
        {
            ToDoTask updatedTask = new ToDoTask()
            {
                Title = titleTextBox.Text,
                Description = descriptionTextBox.Text,
                Priority = Convert.ToInt32(priorityComboBox.Text),
                IsCompleted = isCompletedCheckBox.Checked
            };

            // Вызываю событие TaskUpdated и передаю новый объект задачи
            TaskUpdated?.Invoke(this, updatedTask);

            Close();
        }


    }
}
