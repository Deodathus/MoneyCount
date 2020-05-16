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
        
        public static ITemplateRenderer GetTemplateRenderer()
        {
            return _templateRenderer;
        }
        
        public static string GetTemplate()
        {
            return _template;
        }
        
        public static Dictionary<string, object> GetArguments()
        {
            return Arguments;
        }
        
        public static void SetTemplateRenderer(ITemplateRenderer templateRenderer)
        {
            _templateRenderer = templateRenderer;
        }

        public static void SetTemplate(string template)
        {
            _template = template;
        }

        public static void BuildArguments()
        {
            Arguments.Add("message", "Hi, stranger!");
            Arguments.Add("date", DateTime.Now.ToString("dd-MM"));
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
                AddCustomArgument(customArgument.Key, customArgument.Value.ToString());
            }
            
            _templatePath = path;
        }

        private static void AddCustomArgument(string name, object value)
        {
            if (_customArguments.ContainsKey(name))
            {
                _customArguments.Remove(name);
            }
            
            _customArguments.Add(name, value);
        }

        public static void RebuildCurrentTemplate()
        {
            _template = _templateRenderer.Render(_templatePath, _customArguments);
            
            Console.Clear();

            Console.WriteLine(_template);
            
            _customArguments = new Dictionary<string, object>();
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

        public static void DisplayArguments()
        {
            DisplayArgs(Arguments);
        }

        public static void DisplayCustomArguments()
        {
            DisplayArgs(_customArguments);
        }

        private static void DisplayArgs(Dictionary<string, object> args)
        {
            if (args.Count <= 0)
            {
                Console.WriteLine("Dictionary with arguments is empty.");
            }
            else
            {
                foreach (KeyValuePair<string, object> argument in args)
                {
                    Console.WriteLine($"Name: {argument.Key}, Value: {argument.Value}");
                }
            }
        }
    }
}