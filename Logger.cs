using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GangplankEngine
{
    public static class Logger
    {
        private static int maxLength = 80;

        public static void Log<T>(T message)
        {
            int numOfSpaces = maxLength - message.ToString().Length;
            Console.Write(message);
            Console.Write(" ");
            for (int i = 1; i < numOfSpaces; i++)
                Console.Write(" ");

            Console.WriteLine(CallerClassName + "_" + CallerMethodName);
        }

        public static void Bing()
        {
            Log("Bing!");
        }

        private static string CallerMethodName => new StackTrace().GetFrame(2).GetMethod().Name;

        private static string CallerClassName => new StackTrace().GetFrame(2).GetMethod().ReflectedType.Name;
    }
}
