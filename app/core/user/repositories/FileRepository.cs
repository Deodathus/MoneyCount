using System.Xml.Linq;
using MoneyCount.app.core.config.enums.user;
using MoneyCount.app.core.filesystem.contracts.services;
using MoneyCount.app.core.user.contracts.repositories;
using MoneyCount.app.core.user.dto;

namespace MoneyCount.app.core.user.repositories
{
    public class FileRepository : IRepository
    {
        private IFileService _fileService;

        public FileRepository(IFileService fileService)
        {
            _fileService = fileService;
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
            XElement userId = new XElement("id", user.GetId());
            XElement userName = new XElement("name", user.GetName());
            XElement userPass = new XElement("password", user.GetPassword());
            
            createdUser.Add(userId);
            createdUser.Add(userName);
            createdUser.Add(userPass);

            users?.Add(createdUser);
            users?.Save(UsersFileSettings.FilePath);
        }
    }
}