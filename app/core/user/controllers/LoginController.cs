using System;
using System.Collections.Generic;
using MoneyCount.app.core.config.enums.console;
using MoneyCount.app.core.console;
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

            if (_loginServiceService.UserExists(name))
            {
                Console.WriteLine("Enter your password:");
                string pass = Console.ReadLine();
                if (_loginServiceService.CheckPassword(name, pass))
                {
                    _loginServiceService.LogIn(name, pass);
                    args.Add("userId", LoginService.LoggedUserId);
                    args.Add("userName", name);
                    args.Add("date", DateTime.Now.Day + "-" + DateTime.Now.Month);
                    args.Add("message", "Welcome!");

                    templatePath = ConsoleTemplateFile.LoggedInTemplateFilePath;
                }
                else
                {
                    args.Add("message", "Wrong name or password.");
                }
            }
            else
            {
                args.Add("message", $"User with name '{name}' does not exist.");
            }
            
            Handler.SetRenderedTemplate(Handler.GetTemplateRenderer().Render(templatePath, args));
        }
    }
}