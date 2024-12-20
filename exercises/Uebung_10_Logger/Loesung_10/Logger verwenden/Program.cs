// Verweis auf die DLL hinzufügen
// Namespace unseres Loggers verwenden
using System;
using Logger;

namespace Logger_verwenden
{
    internal class Program
    {
        private static void Main()
        {
            // Logger aufrufen
            Console.WriteLine("Logger");
            LoggerUtil.Init(Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments) + "\\test", "ihk");

            LoggerUtil.WriteToLog("das ist ein logger text1", LoggerUtil.LogTyp.Error);
            LoggerUtil.WriteToLog("das ist ein logger text2", LoggerUtil.LogTyp.Warning);
            LoggerUtil.WriteToLog("das ist ein logger text3", LoggerUtil.LogTyp.Information);
            Console.ReadLine();
        }
    }
}