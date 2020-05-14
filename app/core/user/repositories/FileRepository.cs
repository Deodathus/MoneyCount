using System.IO;
using System.Text.Json;
using System.Xml.Linq;
using MoneyCount.app.core.user.contracts.repositories;
using MoneyCount.app.core.user.dto;

namespace MoneyCount.app.core.user.repositories
{
    public class FileRepository : IRepository
    {
        public void Add(User user)
        {
            XDocument usersList = new XDocument();
            
            XElement users = new XElement("users");
            
            XElement createdUser = new XElement("user");
            XElement userId = new XElement("id", user.GetId());
            XElement userName = new XElement("name", user.GetName());
            XElement userPass = new XElement("password", user.GetPassword());
            
            createdUser.Add(userId);
            createdUser.Add(userName);
            createdUser.Add(userPass);
            
            users.Add(createdUser);
            
            usersList.Add(users);
            usersList.Save("../../../storage/users.xml");
        }

        public void AddJson(User user)
        {
            using StreamWriter fs = new StreamWriter("../../../storage/users.json", false, System.Text.Encoding.Default);
            
            object createdUser = new
            {
                Id = user.GetId(),
                Name = user.GetName(),
                Password = user.GetPassword(),
            };

            fs.Write(JsonSerializer.Serialize(createdUser));
        }
    }
}