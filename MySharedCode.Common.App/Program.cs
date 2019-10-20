using MySharedCode.Common.Infrastructure.Clock;
using System;
using System.Threading;

namespace MySharedCode.Common.App
{
    class Program
    {
        static void Main(string[] args)
        {
            ClockExamples();

            Console.ReadKey();
        }

        private static void ClockExamples()
        {
            var clock = new Clock();

            CWrite("Default clock:", ConsoleColor.Green);
            CWrite($"Now: {clock.Now}", ConsoleColor.Yellow);
            CWrite($"Today: {clock.Today}", ConsoleColor.Yellow);
            clock.Freeze();
            CWrite($"Freeze!", ConsoleColor.Red);
            CWrite($"Now: {clock.Now}", ConsoleColor.Yellow);
            Thread.Sleep(1000);
            CWrite($"Now: {clock.Now}", ConsoleColor.Yellow);
            clock.UnFreeze();
            CWrite($"UnFreeze!", ConsoleColor.Red);
            CWrite($"Now: {clock.Now}", ConsoleColor.Yellow);
            Thread.Sleep(1000);
            CWrite($"Now: {clock.Now}", ConsoleColor.Yellow);

            CWrite("", default);
            CWrite("", default);

            var date = new DateTime(2019, 07, 01, 13, 05, 30);
            clock = new Clock(date.Ticks);
            CWrite("Create clock with datetime (2019-07-01 13:05:30) :", ConsoleColor.Green);
            Thread.Sleep(1000);
            CWrite($"Now: {clock.Now}", ConsoleColor.Yellow);
            CWrite($"Today: {clock.Today}", ConsoleColor.Yellow);
        }

        private static void CWrite(string text, ConsoleColor textColor)
        {
            Console.ForegroundColor = textColor;
            Console.WriteLine(text);
            Console.ResetColor();
        }
    }
}
