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
            Tracer.TaskManagerTrace.TraceEvent(TraceEventType.Start, 0, "Начало AddTask");

            Stopwatch sw = Stopwatch.StartNew();
            Thread.Sleep(1000);
            var task = new TaskItem(title);
            _tasks.Add(task);

            sw.Stop();

            Tracer.TaskManagerTrace.TraceEvent(
                TraceEventType.Stop,
                1,
                $"Завершение AddTask. Добавлена задача '{title}'. Время: {sw.ElapsedMilliseconds} мс"
            );
        }

        public void RemoveTask(string title)
        {
            Tracer.TaskManagerTrace.TraceEvent(TraceEventType.Start, 0, "Начало RemoveTask");

            Stopwatch sw = Stopwatch.StartNew();

            var task = _tasks.FirstOrDefault(t =>
                t.Title.Equals(title, StringComparison.OrdinalIgnoreCase));

            if (task == null)
            {
                Tracer.TaskManagerTrace.TraceEvent(
                    TraceEventType.Warning,
                    2,
                    $"Задача '{title}' не найдена."
                );

                return;
            }

            _tasks.Remove(task);

            sw.Stop();

            Tracer.TaskManagerTrace.TraceEvent(
                TraceEventType.Stop,
                3,
                $"Завершение RemoveTask. Удалена задача '{title}'. Время: {sw.ElapsedMilliseconds} мс"
            );
        }

        public void ListTasks()
{
    Tracer.TaskManagerTrace.TraceEvent(TraceEventType.Start, 0, "Начало ListTasks");

    Stopwatch sw = Stopwatch.StartNew();

    if (_tasks.Count == 0)
    {
        Tracer.TaskManagerTrace.TraceEvent(
            TraceEventType.Warning,
            4,
            "Список задач пуст."
        );

        return;
    }

    sw.Stop();

    Tracer.TaskManagerTrace.TraceEvent(
        TraceEventType.Stop,
        5,
        $"Завершение ListTasks. Всего задач: {_tasks.Count}. Время: {sw.ElapsedMilliseconds} мс"
    );
}
    }
}
