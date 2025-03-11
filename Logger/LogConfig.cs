using NLog;
using NLog.Config;
using NLog.Targets;
using static NLog.LogLevel;

namespace Logger {
    public class LogConfig{

        public static void ConfigureLog() {
            var config = new LoggingConfiguration();
            var logPath = Directory.GetCurrentDirectory();
            var target = new FileTarget { FileName = @logPath+"\\Logger\\ZooManagement.log", Layout = @"${longdate} ${level} - ${logger}: ${message}" };
            config.AddTarget("File Logger", target);
            LogManager.Configuration = config;
        }    
    }
}        