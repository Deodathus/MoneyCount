﻿using System;
using System.Collections.Generic;
using MoneyCount.app.core.config.enums.console;
using MoneyCount.app.core.console;
using MoneyCount.app.core.console.services;
using MoneyCount.app.core.user.contracts.services;
using MoneyCount.app.core.user.dto;
using MoneyCount.app.core.user.states.register;

namespace MoneyCount.app.core.user.controllers
{
    public class RegisterController
    {
        private readonly IRegisterService _registerService;

        public RegisterController(IRegisterService registerService)
        {
            _registerService = registerService;
        }

        public void Do()
        {
            Handler.Write("Enter your name:");
            string name = Handler.Read().ToString();
            Handler.Write("Enter your password:");
            string password = Handler.Read().ToString();
            User user = new User(name, password);

            Dictionary<string, object> args = new Dictionary<string, object>();

            try
            {
                _registerService.RegisterUser(user);
                args.Add("message", "Success!");
                StateController.State = new RegisterSuccessState();
            }
            catch (Exception e)
            {
                args.Add("message", "Error!");
                StateController.State = new RegisterUnsuccessState();
            }

            TemplateBuilder.BuildTemplate(ConsoleTemplateFile.TemplateFilePath, args);
        }
    }
}