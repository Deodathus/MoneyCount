using System.IO;
using MoneyCount.app.core.account.contracts.repositories;
using MoneyCount.app.core.account.dto;
using MoneyCount.app.core.config.enums.account;

namespace MoneyCount.app.core.account.repositories
{
    public class FileAccountRepository : IAccountRepository
    {
        public void Add(Account account)
        {
            using BinaryWriter binaryWriter = new BinaryWriter(File.Open(AccountFileSettings.FilePath, FileMode.Create));
            
            binaryWriter.Write(300);
            binaryWriter.Write(500);
        }

        public bool AccountExistsById(int id)
        {
            throw new System.NotImplementedException();
        }

        public Account GetAccountById(int id)
        {
            throw new System.NotImplementedException();
        }

        public void RemoveById(int id)
        {
            throw new System.NotImplementedException();
        }
    }
}