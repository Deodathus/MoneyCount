using System;
using System.Collections.Generic;
using MoneyCount.app.core.config.enums.console;
using MoneyCount.app.core.console;
using MoneyCount.app.core.user.contracts.services;
using MoneyCount.app.core.user.dto;

namespace MoneyCount.app.core.user.controllers
{
    public class RegisterController
    {
        private readonly IRegister _registerService;

        public RegisterController(IRegister registerService)
        {
            _registerService = registerService;
        }

        public void Do()
        {
            Console.WriteLine("Enter your name:");
            string name = Console.ReadLine();
            Console.WriteLine("Enter your password:");
            string password = Console.ReadLine();
            User user = new User(name, password);

            Dictionary<string, object> args = new Dictionary<string, object>();

            try
            {
                _registerService.RegisterUser(user);
                args.Add("message", "Success!");
            }
            catch (Exception e)
            {
                args.Add("message", "Error!");
            }

            Handler.SetRenderedTemplate(Handler.GetTemplateRenderer().Render(ConsoleTemplateFile.TemplateFilePath, args));
        }
    }
}