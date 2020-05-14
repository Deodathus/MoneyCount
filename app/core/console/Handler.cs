using System;
using MoneyCount.app.core.config.enums.console;
using MoneyCount.app.core.console.contracts.services;

namespace MoneyCount.app.core.console
{
    public class Handler
    {
        private static ITemplateRenderer _renderer;
        private static string _renderedTemplate;

        public Handler(ITemplateRenderer templateRenderer)
        {
            _renderer = templateRenderer;
            _renderedTemplate = _renderer.Render(ConsoleTemplateFile.TemplateFilePath);
        }

        public static ITemplateRenderer GetTemplateRenderer()
        {
            return _renderer;
        }

        public static void SetRenderedTemplate(string renderedTemplate)
        {
            _renderedTemplate = renderedTemplate;
        }

        public void Start()
        {
            bool active = true;

            do
            {
                Console.WriteLine(_renderedTemplate);
                int chosenOption = Convert.ToInt32(Console.ReadLine());
                
                switch (chosenOption)
                {
                    case 0:
                        active = false;
                        
                        break;
                    default:
                        ApplicationState.Handle(chosenOption);
                        
                        break;
                }
                Console.Clear();
            } while (active);
        }
    }
}