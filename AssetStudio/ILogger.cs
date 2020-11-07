using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IO;

namespace AssetStudio
{
    public enum LoggerEvent
    {
        Verbose,
        Debug,
        Info,
        Warning,
        Error,
    }

    public interface ILogger
    {
        void Log(LoggerEvent loggerEvent, string message);
    }

    public sealed class DummyLogger : ILogger
    {
        public void Log(LoggerEvent loggerEvent, string message) { }
    }

    public sealed class FileLogger : ILogger
    {
        private StreamWriter file;

        public FileLogger()
        {
            this.file = File.AppendText("log.txt");
        }

        public void Log(LoggerEvent loggerEvent, string message)
        {
            this.file.WriteLine(message);
        }
    }
}
