using System.IO;
using MoneyCount.app.core.account.contracts.repositories;
using MoneyCount.app.core.account.dto;
using MoneyCount.app.core.account.exceptions;
using MoneyCount.app.core.config.enums.account;
using MoneyCount.app.core.filesystem.contracts.services;
using MoneyCount.app.core.user.contracts.repositories;
using MoneyCount.app.core.user.dto;

namespace MoneyCount.app.core.account.repositories
{
    public class FileAccountRepository : IAccountRepository
    {
        private IUserRepository _userRepository;
        private IFileService _fileService;

        public FileAccountRepository(IUserRepository userRepository, IFileService fileService)
        {
            _userRepository = userRepository;
            _fileService = fileService;
        }

        public void SetUserRepository(IUserRepository userRepository)
        {
            _userRepository = userRepository;
        }

        public IUserRepository GetUserRepository()
        {
            return _userRepository;
        }

        public void Add(Account account)
        {
            using BinaryWriter binaryWriter = new BinaryWriter(File.Open(AccountFileSettings.FilePath, FileMode.Append));
            
            binaryWriter.Write(account.GetUser().GetId());
            binaryWriter.Write(account.GetBalance());
        }

        public Account GetAccountByUserId(int userId)
        {
            if (_userRepository.UserExistsById(userId) && _fileService.FileExist(AccountFileSettings.FilePath))
            {
                using BinaryReader binaryReader = new BinaryReader(File.Open(AccountFileSettings.FilePath, FileMode.Open));
                while (binaryReader.PeekChar() > -1)
                {
                    int ui = binaryReader.ReadInt32();
                    int balance = binaryReader.ReadInt32();

                    if (ui == userId)
                    {
                        User user = _userRepository.GetUserById(userId);
                        
                        return new Account(user, balance);
                    }
                }
            }
            
            throw new AccountDoesNotExist();
        }

        public bool AccountExistsById(int id)
        {
            throw new System.NotImplementedException();
        }

        public void RemoveById(int id)
        {
            throw new System.NotImplementedException();
        }
    }
}