using System;
using System.Collections.Generic;
using MoneyCount.app.core.config.enums.console;
using MoneyCount.app.core.console.services;
using MoneyCount.app.core.user.contracts.services;
using MoneyCount.app.core.user.services;

namespace MoneyCount.app.core.user.controllers
{
    public class LoginController
    {
        private readonly ILoginService _loginServiceService;

        public LoginController(ILoginService loginServiceService)
        {
            _loginServiceService = loginServiceService;
        }

        public void Do()
        {
            string templatePath = ConsoleTemplateFile.TemplateFilePath;
            
            Console.WriteLine("Enter your name:");
            string name = Console.ReadLine();
            Dictionary<string, object> args = new Dictionary<string, object>();
            
            Console.WriteLine("Enter your password:");
            string pass = Console.ReadLine();
            if (_loginServiceService.CheckPassword(name, pass))
            {
                _loginServiceService.LogIn(name, pass);
                
                TemplateBuilder.AddArgument("userId", LoginService.LoggedUserId);
                TemplateBuilder.AddArgument("userName", name);

                templatePath = ConsoleTemplateFile.LoggedInTemplateFilePath;
            }
            else
            {
                args.Add("message", "Wrong name or password.");
            }

            TemplateBuilder.BuildTemplate(templatePath, args);
        }
    }
}