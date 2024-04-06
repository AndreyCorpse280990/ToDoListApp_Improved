﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ToDoListApp_Improved.Tasks
{
    // ToDoTask - класс, описывающий задачу (дело), которую надо сделать
    public class ToDoTask : ICloneable
    {
        public string Title { get; set; }       // заголовок задачи
        public string Description { get; set; } // описание задачи
        public int Priority { get; set; }       // приоритет задачи
        public bool IsCompleted { get; set; }   // выполнена ли данная задача

        public ToDoTask() { }

        public override string ToString()
        {
            string data = $"{Title} - {Description} ({Priority})";
            if (IsCompleted)
            {
                data += " (completed)";
            }
            return data;
        }

        public object Clone()
        {
            return new ToDoTask()
            {
                Title= Title,
                Description= Description,
                Priority= Priority,
                IsCompleted= IsCompleted
            };
        }
    }
}
