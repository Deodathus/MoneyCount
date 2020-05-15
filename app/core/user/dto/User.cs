using System.Text;

namespace MoneyCount.app.core.user.dto
{
    public class User
    {
        private readonly int _id;
        private string _name;
        private readonly string _password;

        public User(string name, string password, int id = default)
        {
            _name = name;
            _password = password;

            _id = id;
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
            return EncodePassword(_password);
        }

        public bool CheckPassword(string pass)
        {
            return EncodePassword(pass) == _password;
        }

        private string EncodePassword(string pass)
        {
            string password = "";
            byte[] passBytes = Encoding.ASCII.GetBytes(pass);

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