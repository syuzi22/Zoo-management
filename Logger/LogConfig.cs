using NLog;
using NLog.Config;
using NLog.Targets;

namespace Zoo_management.Logger {
    public class LogConfig{

        public static void ConfigureLog() {
            var config = new LoggingConfiguration();
            var logPath = Directory.GetCurrentDirectory();
            var target = new FileTarget { FileName = @logPath+"\\Logger\\ZooManagement.log", Layout = @"${longdate} ${level} - ${logger}: ${message}" };
            config.AddTarget("File Logger", target);
            config.LoggingRules.Add(new LoggingRule("*", NLog.LogLevel.Debug, target)); 
            LogManager.Configuration = config;
        }    
    }
}        