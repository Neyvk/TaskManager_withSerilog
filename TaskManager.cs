using Serilog;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;

namespace ConsoleApp26
{
    public class TaskManager
    {
        private readonly List<TaskItem> _tasks = new();

        public void AddTask(string title)
        {
            Log.Verbose("Начало операции AddTask.");

            _tasks.Add(new TaskItem(title));

            Log.Information($"Задача \"{title}\" успешно добавлена.");

            Log.Information($"Количество задач после добавления: {_tasks.Count}");

            Log.Verbose("Конец операции AddTask.");
        }

        public void RemoveTask(string title)
        {
            Log.Verbose("Начало операции RemoveTask.");

            var task = _tasks.FirstOrDefault(t =>
                t.Title.Equals(title, StringComparison.OrdinalIgnoreCase));

            if (task == null)
            {
                Log.Error($"Задача \"{title}\" не найдена.");

                Log.Verbose("Конец операции RemoveTask.");
                return;
            }

            _tasks.Remove(task);

            Log.Information($"Задача \"{title}\" успешно удалена.");

            Log.Information($"Количество задач после удаления: {_tasks.Count}");

            Log.Verbose("Конец операции RemoveTask.");
        }

        public void ListTasks()
        {
            Log.Verbose("Начало операции ListTasks.");

            if (_tasks.Count == 0)
            {
                Log.Information("Список задач пуст.");

                Log.Verbose("Конец операции ListTasks.");
                return;
            }

            Log.Information($"Всего задач: {_tasks.Count}");

            Log.Verbose("Конец операции ListTasks.");
        }
    }
}
