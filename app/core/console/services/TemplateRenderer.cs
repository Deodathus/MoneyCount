using System.Collections.Generic;
using System.IO;
using MoneyCount.app.core.console.contracts.services;

namespace MoneyCount.app.core.console.services
{
    public class TemplateRenderer : ITemplateRenderer
    {
        private string ReadTemplate(string path)
        {
            return File.ReadAllText(path);
        }

        public string Render(string path)
        {
            string template = ReadTemplate(path);
            
            template = ReplaceDefaultArguments(template);
            
            return template;
        }

        public string Render(string path, Dictionary<string, object> args)
        {
            string template = ReadTemplate(path);

            template = ReplaceCustomArguments(template, args);
            template = ReplaceDefaultArguments(template);

            return template;
        }

        private string ReplaceDefaultArguments(string template)
        {
            foreach (KeyValuePair<string, object> defaultArgument in TemplateBuilder.GetArguments())
            {
                template = template.Replace($"%{defaultArgument.Key}%", defaultArgument.Value.ToString());
            }

            return template;
        }

        private string ReplaceCustomArguments(string template, Dictionary<string, object> args)
        {
            foreach (KeyValuePair<string, object> arg in args)
            {
                template = template.Replace($"%{arg.Key}%", arg.Value.ToString());
            }

            return template;
        }
    }
}