using System.Collections.Generic;
using System.IO;
using MoneyCount.app.core.console.contracts.services;

namespace MoneyCount.app.core.console.services
{
    public class TemplateRenderer : ITemplateRenderer
    {
        public string Render(string path)
        {
            return File.ReadAllText(path);
        }

        public string Render(string path, Dictionary<string, object> args)
        {
            string template = Render(path);

            foreach (KeyValuePair<string, object> arg in args)
            {
                template = template.Replace($"%{arg.Key}%", arg.Value.ToString());
            }

            return template;
        }
    }
}