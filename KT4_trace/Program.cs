using Serilog;
using Serilog.Formatting.Json;
using System;
using System.Diagnostics;
using System.IO;

namespace ConsoleApp26
{
    class Program
    {
        static void Main()
        {
            Tracer.TaskManagerTrace.Switch = new SourceSwitch("SourceSwitch", "All");
            Tracer.TaskManagerTrace.Listeners.Add(new ConsoleTraceListener());
            Tracer.TaskManagerTrace.Listeners.Add(new TextWriterTraceListener("taskmanagerTrace.log"));

            Tracer.TaskManagerTrace.TraceEvent(TraceEventType.Start, 0, "Программа TaskManager запущена");
            Console.WriteLine("TaskManager запущен. Команды: add, remove, list, exit");

            var manager = new TaskManager();

            while (true)
            {
                Console.Write("> ");
                var command = Console.ReadLine()?.Trim().ToLower();

                switch (command)
                {
                    case "add":
                        Console.Write("Введите название задачи: ");
                        manager.AddTask(Console.ReadLine());
                        break;

                    case "remove":
                        Console.Write("Введите название задачи для удаления: ");
                        manager.RemoveTask(Console.ReadLine());
                        break;

                    case "list":
                        manager.ListTasks();
                        break;

                    case "exit":
                        Tracer.TaskManagerTrace.TraceEvent(TraceEventType.Stop, 0, "Программа TaskManager завершена");
                        Tracer.TaskManagerTrace.Flush();
                        Tracer.TaskManagerTrace.Close();
                        return;

                    default:
                        continue;
                }
            }

        }
    }
}
