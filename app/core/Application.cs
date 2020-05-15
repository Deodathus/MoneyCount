using MoneyCount.app.core.config.enums.console;
using MoneyCount.app.core.console;
using MoneyCount.app.core.console.contracts.services;
using MoneyCount.app.core.console.services;

namespace MoneyCount.app.core
{
    public class Application
    {
        public void Start()
        {
            Bootstrap();
            
            Handler consoleHandler = new Handler();
            
            consoleHandler.Start();
        }

        private void Bootstrap()
        {
            Builder.Build();
            
            ITemplateRenderer templateRenderer = new TemplateRenderer();
            TemplateBuilder.SetTemplateRenderer(templateRenderer);
            TemplateBuilder.BuildArguments();
            TemplateBuilder.BuildTemplate(ConsoleTemplateFile.TemplateFilePath);
        }
    }
}