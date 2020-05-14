using System;
using System.Collections.Generic;
using MoneyCount.app.core.filesystem.contracts.services;
using MoneyCount.app.core.filesystem.services;
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
        private static readonly Dictionary<string, object> Repositories = new Dictionary<string, object>();
        private static readonly Dictionary<string, object> Services = new Dictionary<string, object>();
        private static readonly Dictionary<string, object> Controllers = new Dictionary<string, object>();
        
        public static void Build()
        {
            BuildMainServices();
            BuildRepositories();
            BuildServices();
            BuildControllers();
        }

        private static void BuildMainServices()
        {
            IFileService fs = new FileService();
            MainServices.Add(typeof(IFileService).ToString(), fs);
        }

        private static void BuildRepositories()
        {
            IRepository ufr = new FileRepository((IFileService) MainServices[typeof(IFileService).ToString()]);
            Repositories.Add(typeof(IRepository).ToString(), ufr);
        }

        private static void BuildServices()
        {
            IRegister urs = new Register((IRepository) Repositories[typeof(IRepository).ToString()]);
            Services.Add(typeof(IRegister).ToString(), urs);
        }

        private static void BuildControllers()
        {
            RegisterController urc = new RegisterController((IRegister) Services[typeof(IRegister).ToString()]);
            Controllers.Add(typeof(RegisterController).ToString(), urc);
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