using Serilog;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TaskManager
{
    public static class ExceptionHandler
    {
        public static void Run(string OperationDescription, Action action)
        {
            try
            {
                Log.Verbose("Начало операции {Operation}", OperationDescription);
                action();
                Log.Verbose("Конец операции {Operation}", OperationDescription);
            }
            catch (Exception ex)
            {
                Log.Error(ex, "Ошибка во время операции {Operation}. Текст ошибки: {ErrorMessage}", OperationDescription, ex.Message);
            }
        }
    }
}
