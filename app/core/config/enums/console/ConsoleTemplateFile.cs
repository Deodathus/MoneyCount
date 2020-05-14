using System;

namespace MoneyCount.app.core.config.enums.console
{
    public struct ConsoleTemplateFile
    {
        public static readonly string TemplateFilePath = AppDomain.CurrentDomain.BaseDirectory + "/storage/console/template/start.txt";
        public static readonly string LoggedInTemplateFilePath = AppDomain.CurrentDomain.BaseDirectory + "/storage/console/template/logged.txt";
    }
}