using System;
using System.Collections.Generic;
using MoneyCount.app.core.config.enums;
using MoneyCount.app.core.console.contracts.services;

namespace MoneyCount.app.core.console.services
{
    public static class TemplateBuilder
    {
        private static ITemplateRenderer _templateRenderer;
        private static string _template;
        private static string _templatePath;
        
        private static readonly Dictionary<string, object> Arguments = new Dictionary<string, object>();
        private static Dictionary<string, object> _customArguments = new Dictionary<string, object>();
        
        public static void BuildArguments()
        {
            Arguments.Add("message", "Hi, stranger!");
            Arguments.Add("date", DateTime.Now.Day + "-" + DateTime.Now.Month);
            Arguments.Add("version", App.Version);
        }

        public static void BuildTemplate(string path)
        {
            _template = _templateRenderer.Render(path);
            _templatePath = path;
        }

        public static void BuildTemplate(string path, Dictionary<string, object> args)
        {
            _template = _templateRenderer.Render(path, args);

            foreach (KeyValuePair<string, object> customArgument in args)
            {
                _customArguments.Add(customArgument.Key, customArgument.Value.ToString());
            }
            
            _templatePath = path;
        }

        public static void RebuildCurrentTemplate()
        {
            _template = _templateRenderer.Render(_templatePath, _customArguments);
            
            _customArguments = new Dictionary<string, object>();
        }

        public static void SetTemplateRenderer(ITemplateRenderer templateRenderer)
        {
            _templateRenderer = templateRenderer;
        }

        public static ITemplateRenderer GetTemplateRenderer()
        {
            return _templateRenderer;
        }
        
        public static string GetTemplate()
        {
            return _template;
        }

        public static void SetTemplate(string template)
        {
            _template = template;
        }

        public static Dictionary<string, object> GetArguments()
        {
            return Arguments;
        }

        public static void AddArgument(string name, object value)
        {
            if (Arguments.ContainsKey(name))
            {
                Arguments.Remove(name);
            }

            
            Arguments.Add(name, value);
        }

        public static void AddArguments(Dictionary<string, object> args)
        {
            foreach (KeyValuePair<string, object> arg in args)
            {
                AddArgument(arg.Key, arg.Value.ToString());
            }
        }
    }
}