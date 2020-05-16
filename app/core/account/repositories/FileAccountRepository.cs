using System.Collections.Generic;
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
        private static int _count;
        private IUserRepository _userRepository;
        private IFileService _fileService;

        public FileAccountRepository(IUserRepository userRepository, IFileService fileService)
        {
            _userRepository = userRepository;
            _fileService = fileService;

            _count = GetAccountsCount();
        }

        public void SetUserRepository(IUserRepository userRepository)
        {
            _userRepository = userRepository;
        }

        public IUserRepository GetUserRepository()
        {
            return _userRepository;
        }

        public void SetFileService(IFileService fileService)
        {
            _fileService = fileService;
        }

        public IFileService GetFileService()
        {
            return _fileService;
        }

        public void Add(Account account)
        {
            using BinaryWriter binaryWriter = new BinaryWriter(File.Open(AccountFileSettings.FilePath, FileMode.Append));
            
            WriteAccountInformation(binaryWriter, account);

            _count++;
        }

        private void WriteAccountInformation(BinaryWriter binaryWriter, Account account)
        {
            binaryWriter.Write(_count);
            binaryWriter.Write(account.GetUser().GetId());
            binaryWriter.Write(account.GetBalance());
        }

        public int GetAccountsCount()
        {
            if (_fileService.FileExist(AccountFileSettings.FilePath))
            {
                return 1 + GetAllAccounts().Count;
            }

            return 0;
        }

        public List<Account> GetAccountsByUserId(int userId)
        {
            List<Account> accounts = GetAllAccounts();
            List<Account> foundedAccounts = new List<Account>();

            foreach (Account acc in accounts)
            {
                if (acc.GetUser().GetId() == userId)
                {
                    foundedAccounts.Add(acc);
                }
            }

            if (foundedAccounts.Count <= 0)
            {
                throw new AccountDoesNotExist();
            }

            return foundedAccounts;
        }

        private List<Account> GetAllAccounts()
        {
            List<Account> accounts = new List<Account>();
            
            if (_fileService.FileExist(AccountFileSettings.FilePath))
            {
                using BinaryReader binaryReader = new BinaryReader(File.Open(AccountFileSettings.FilePath, FileMode.Open));
                
                while (binaryReader.PeekChar() > -1)
                {
                    int id = binaryReader.ReadInt32();
                    int ui = binaryReader.ReadInt32();
                    int balance = binaryReader.ReadInt32();
                    
                    User user = _userRepository.GetUserById(ui);
                        
                    accounts.Add(new Account(user, balance, id));
                }
            }
            
            return accounts;
        }

        public bool AccountExistsById(int id)
        {
            foreach (Account account in GetAllAccounts())
            {
                if (account.GetId() == id)
                {
                    return true;
                }
            }
            
            return false;
        }

        public void RemoveById(int id)
        {
            List<Account> accounts = GetAllAccounts();

            foreach (Account account in accounts)
            {
                if (account.GetId() == id)
                {
                    accounts.Remove(account);
                }
            }
            
            OverwriteAccountsFile(accounts);
        }

        private void OverwriteAccountsFile(List<Account> accounts)
        {
            using BinaryWriter binaryWriter = new BinaryWriter(File.Open(AccountFileSettings.FilePath, FileMode.Create));

            foreach (Account account in accounts)
            {
                WriteAccountInformation(binaryWriter, account);
            }
        }
    }
}