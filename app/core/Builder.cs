using System;
using System.Collections.Generic;
using MoneyCount.app.core.account.contracts.repositories;
using MoneyCount.app.core.account.contracts.services;
using MoneyCount.app.core.account.controllers;
using MoneyCount.app.core.account.repositories;
using MoneyCount.app.core.account.services;
using MoneyCount.app.core.filesystem.contracts.services;
using MoneyCount.app.core.filesystem.services;
using MoneyCount.app.core.user;
using MoneyCount.app.core.user.contracts.repositories;
using MoneyCount.app.core.user.contracts.services;
using MoneyCount.app.core.user.controllers;
using MoneyCount.app.core.user.repositories;
using MoneyCount.app.core.user.services;

namespace MoneyCount.app.core
{
    public static class Builder
    {
        private static readonly Dictionary<string, object> MainServices = new Dictionary<string, object>();
        private static readonly Dictionary<string, object> StateControllers = new Dictionary<string, object>();
        private static readonly Dictionary<string, object> Repositories = new Dictionary<string, object>();
        private static readonly Dictionary<string, object> Services = new Dictionary<string, object>();
        private static readonly Dictionary<string, object> Controllers = new Dictionary<string, object>();

        public static void Build()
        {
            BuildMainServices();
            BuildStateControllers();
            BuildRepositories();
            BuildServices();
            BuildControllers();
        }

        private static void BuildMainServices()
        {
            IFileService fs = new FileService();
            MainServices.Add(typeof(IFileService).ToString(), fs);
        }

        private static void BuildStateControllers()
        {
            StateController usc = new StateController();
            StateControllers.Add(typeof(StateController).ToString(), usc);
            
            account.StateController asc = new account.StateController();
            StateControllers.Add(typeof(account.StateController).ToString(), asc);
        }

        private static void BuildRepositories()
        {
            IUserRepository ufr = new FileUserRepository((IFileService) MainServices[typeof(IFileService).ToString()]);
            Repositories.Add(typeof(IUserRepository).ToString(), ufr);
            
            IAccountRepository afr = new FileAccountRepository();
            Repositories.Add(typeof(IAccountRepository).ToString(), afr);
        }

        private static void BuildServices()
        {
            IRegisterService urs = new RegisterService((IUserRepository) Repositories[typeof(IUserRepository).ToString()]);
            Services.Add(typeof(IRegisterService).ToString(), urs);
            
            ILoginService uls = new LoginService((IUserRepository) Repositories[typeof(IUserRepository).ToString()]);
            Services.Add(typeof(ILoginService).ToString(), uls);
            
            IManageService ams = new ManageService(
                (IUserRepository) Repositories[typeof(IUserRepository).ToString()],
                (IAccountRepository) Repositories[typeof(IAccountRepository).ToString()]
            );
            Services.Add(typeof(IManageService).ToString(), ams);
        }

        private static void BuildControllers()
        {
            RegisterController urc = new RegisterController((IRegisterService) Services[typeof(IRegisterService).ToString()]);
            Controllers.Add(typeof(RegisterController).ToString(), urc);
            
            LoginController ulc = new LoginController((ILoginService) Services[typeof(ILoginService).ToString()]);
            Controllers.Add(typeof(LoginController).ToString(), ulc);
            
            AccountManageController amc = new AccountManageController((IManageService) Services[typeof(IManageService).ToString()]);
            Controllers.Add(typeof(AccountManageController).ToString(), amc);
        }

        public static object GetMainService(Type type)
        {
            try
            {
                return MainServices[type.ToString()];
            }
            catch (KeyNotFoundException e)
            {
                Console.WriteLine(e);
                throw;
            }
        }

        public static object GetStateController(Type type)
        {
            try
            {
                return StateControllers[type.ToString()];
            }
            catch (KeyNotFoundException e)
            {
                Console.WriteLine(e);
                throw;
            }
        }

        public static object GetRepository(Type type)
        {
            try
            {
                return Repositories[type.ToString()];
            }
            catch (KeyNotFoundException e)
            {
                Console.WriteLine(e);
                throw;
            }
        }

        public static object GetService(Type type)
        {
            try
            {
                return Services[type.ToString()];
            }
            catch (KeyNotFoundException e)
            {
                Console.WriteLine(e);
                throw;
            }
        }

        public static object GetController(Type type)
        {
            try
            {
                return Controllers[type.ToString()];
            }
            catch (KeyNotFoundException e)
            {
                Console.WriteLine(e);
                throw;
            }
        }
    }
}