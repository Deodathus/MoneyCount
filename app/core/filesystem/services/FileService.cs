using System.IO;
using MoneyCount.app.core.filesystem.contracts.services;

namespace MoneyCount.app.core.filesystem.services
{
    public class FileService : IFileService
    {
        public bool FileExist(string path)
        {
            FileInfo fi = new FileInfo(path);

            return fi.Exists;
        }
    }
}