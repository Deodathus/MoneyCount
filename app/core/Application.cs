using System;
using System.Collections.Generic;
using MoneyCount.app.core.user.dto;
using MoneyCount.app.core.user.repositories;
using MoneyCount.app.core.user.services;

namespace MoneyCount.app.core
{
    public class Application
    {
        private static readonly  List<User> Users = new List<User>();

        public void Start()
        {
            Console.WriteLine("Enter login");
            string login = Console.ReadLine();
            Console.WriteLine("Enter password");
            string password = Console.ReadLine();

            User user = new User(login, password);
            
            FileRepository repository = new FileRepository();
            Register register = new Register(repository);
            register.RegisterUser(user);

            foreach (User client in Users)
            {
                Console.WriteLine("Users:");
                Console.WriteLine("----------------------------------------");
                Console.WriteLine("ID: " + client.GetId());
                Console.WriteLine("Name: " + client.GetName());
                Console.WriteLine("Password: " + client.GetPassword());
                Console.WriteLine("----------------------------------------");
            }
        }

        public static List<User> GetUsers()
        {
            return Users;
        }

        public static void AddUser(User user)
        {
            Users.Add(user);
        }
    }
}