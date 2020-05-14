using System.Collections.Generic;

namespace MoneyCount.app.core.console.contracts.services
{
    public interface ITemplateRenderer
    {
        public string Render(string path);
        public string Render(string path, Dictionary<string, object> args);
    }
}