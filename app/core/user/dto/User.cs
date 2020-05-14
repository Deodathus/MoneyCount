using System.Text;
using MoneyCount.app.core.account.dto;

namespace MoneyCount.app.core.user.dto
{
    public class User
    {
        private static int _count = 1;
        
        private readonly int _id;
        private string _name;
        private readonly string _password;

        private Account _account;

        public User(string name, string password)
        {
            _id = _count;
            _name = name;
            _password = password;

            RegisterAccount();
            _count++;
        }

        private void RegisterAccount()
        {
            _account = new Account(this);
            Application.AddUser(this);
        }

        public int GetId()
        {
            return _id;
        }

        public string GetName()
        {
            return _name;
        }

        public string GetPassword()
        {
            string password = "";
            byte[] passBytes = Encoding.ASCII.GetBytes(_password);

            foreach (byte passByte in passBytes)
            {
                password += passByte + " ";
            }
            
            return password;
        }

        public void SetName(string name)
        {
            _name = name;
        }
    }
}