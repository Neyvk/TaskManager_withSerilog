using Serilog;
using Serilog.Formatting.Json;
using System;
using System.Diagnostics;
using System.IO;

namespace ConsoleApp26
{
    using Serilog;
    using Serilog.Formatting.Json;
    using System;

    class Program
    {
        static void Main()
        {
            Log.Logger = new LoggerConfiguration()
                .MinimumLevel.Verbose()
                .WriteTo.Console(
                    outputTemplate: "[{Timestamp:HH:mm:ss} {Level:u3}] {Message:lj}{NewLine}{Exception}")
                .WriteTo.File(
                    new JsonFormatter(),
                    "logs/app.json",
                    rollingInterval: RollingInterval.Day)
                .CreateLogger();

            Log.Verbose("TaskManager запущен");
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
                        Log.Verbose("Выход из программы");
                        Log.CloseAndFlush();
                        return;

                    default:
                        continue;
                }
            }
        }
    }
}
