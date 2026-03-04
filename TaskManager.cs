using Serilog;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using TaskManager;

namespace ConsoleApp26
{
    public class TaskManager
    {
        private readonly List<TaskItem> _tasks = new();

        public void AddTask(string title)
        {
            ExceptionHandler.Run("addtask", () =>
            {
                var task = new TaskItem(title);
                _tasks.Add(task);

                Log.Information("задача \"{title}\" успешно добавлена.", task.Title, task);

                Log.Information("количество задач после добавления: {count}", _tasks.Count);
            });


        }

        public void RemoveTask(string title)
        {
            ExceptionHandler.Run("removetask", () =>
            {
                var task = _tasks.FirstOrDefault(t =>
                t.Title.Equals(title, StringComparison.OrdinalIgnoreCase));

                if (task == null)
                {
                    throw new InvalidOperationException($"Задача \"{title}\" не найдена");
                }


                _tasks.Remove(task);

                Log.Information($"Задача \"{title}\" успешно удалена.");

                Log.Information($"Количество задач после удаления: {_tasks.Count}");
            });
        }

        public void ListTasks()
        {
            ExceptionHandler.Run("listtasks", () =>
            {
                if (_tasks.Count == 0)
                {
                    Log.Information("Список задач пуст.");

                    Log.Verbose("Конец операции ListTasks.");
                    return;
                }

                Log.Information($"Всего задач: {_tasks.Count}");
            });
        }
    }
}
