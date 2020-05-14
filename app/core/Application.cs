using MoneyCount.app.core.console;
using MoneyCount.app.core.console.contracts.services;
using MoneyCount.app.core.console.services;

namespace MoneyCount.app.core
{
    public class Application
    {
        public void Start()
        {
            Builder.Build();
            
            ITemplateRenderer templateRenderer = new TemplateRenderer();
            Handler consoleHandler = new Handler(templateRenderer);
            
            consoleHandler.Start();
        }
    }
}