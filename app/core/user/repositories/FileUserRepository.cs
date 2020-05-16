using System;
using System.Collections.Generic;
using System.Linq;
using System.Xml.Linq;
using MoneyCount.app.core.config.enums.user;
using MoneyCount.app.core.filesystem.contracts.services;
using MoneyCount.app.core.user.contracts.repositories;
using MoneyCount.app.core.user.dto;
using MoneyCount.app.core.user.exceptions;

namespace MoneyCount.app.core.user.repositories
{
    public class FileUserRepository : IUserRepository
    {
        private static int _count;
        private IFileService _fileService;

        public FileUserRepository(IFileService fileService)
        {
            _fileService = fileService;
            _count = GetUsersCount();
        }

        public IFileService GetFileService()
        {
            return _fileService;
        }

        public void SetFileService(IFileService fileService)
        {
            _fileService = fileService;
        }

        public void Add(User user)
        {
            if (! _fileService.FileExist(UsersFileSettings.FilePath))
            {
                CreateUsersFile();
            }
            
            AddUserToFile(user);
        }

        private void CreateUsersFile()
        {
            XDocument usersList = new XDocument();
            XElement users = new XElement("users");
            usersList.Add(users);
            usersList.Save(UsersFileSettings.FilePath);
        }

        private void AddUserToFile(User user)
        {
            XDocument usersList = XDocument.Load(UsersFileSettings.FilePath);
            XElement users = usersList.Root;
            
            XElement createdUser = new XElement("user");
            XElement userId = new XElement("id", _count);
            XElement userName = new XElement("name", user.GetName());
            XElement userPass = new XElement("password", user.GetPassword());
            
            createdUser.Add(userId);
            createdUser.Add(userName);
            createdUser.Add(userPass);

            users?.Add(createdUser);
            users?.Save(UsersFileSettings.FilePath);
            _count++;
        }

        private int GetUsersCount()
        {
            if (_fileService.FileExist(UsersFileSettings.FilePath))
            {
                XDocument usersList = XDocument.Load(UsersFileSettings.FilePath);
                
                return 1 + usersList.Element("users").Elements("user").Count();
            }

            return 1;
        }

        private XDocument GetUsersFile()
        {
            return XDocument.Load(UsersFileSettings.FilePath);
        }

        public bool UserExistsById(int id)
        {
            if (_fileService.FileExist(UsersFileSettings.FilePath))
            {
                XDocument usersList = GetUsersFile();

                IEnumerable<XElement> foundedUsers = from user in usersList.Element("users")?.Elements("user")
                    where Convert.ToInt32(user.Element("id")?.Value) == id
                    select user;
                if (foundedUsers.Any(u => Convert.ToInt32(u.Element("id").Value) == id))
                {
                    return true;
                }
            }

            return false;
        }

        public bool UserExistsByName(string name)
        {
            if (_fileService.FileExist(UsersFileSettings.FilePath))
            {
                XDocument usersList = XDocument.Load(UsersFileSettings.FilePath);

                IEnumerable<XElement> foundedUsers = from user in usersList.Element("users")?.Elements("user")
                    where user.Element("name")?.Value == name
                    select user;

                if (foundedUsers.Any(u => u.Element("name").Value == name))
                {
                    return true;
                }
            }

            return false;
        }

        public User GetUserByName(string name)
        {
            if (_fileService.FileExist(UsersFileSettings.FilePath))
            {
                XDocument usersList = XDocument.Load(UsersFileSettings.FilePath);

                var user = from u in usersList.Element("users").Elements("user")
                    where u.Element("name").Value == name
                    select new User(u.Element("name").Value, u.Element("password").Value, Convert.ToInt32(u.Element("id").Value));

                return user.First();
            }
            
            throw new UserDoesNotExist("User does not exist.");
        }

        public User GetUserById(int id)
        {
            if (_fileService.FileExist(UsersFileSettings.FilePath))
            {
                XDocument usersList = XDocument.Load(UsersFileSettings.FilePath);

                var user = from u in usersList.Element("users").Elements("user")
                    where u.Element("id").Value == id.ToString()
                    select new User(u.Element("name").Value, u.Element("password").Value, Convert.ToInt32(u.Element("id").Value));

                return user.First();
            }
            
            throw new UserDoesNotExist("User does not exist.");
        }
    }
}