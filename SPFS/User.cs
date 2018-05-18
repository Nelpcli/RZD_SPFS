using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SPFS
{
    public class User
    {
        public string Login;
        string Password;
        public int ID;
        int Rule;
        public enum Rules { All,Read, Write};
        int Sector;

        public User(string login,string password)
        {
            Login = login;
            Password = password;
        }

        public void SetRules(Rules R)
        {
            switch (R)
            {
                case Rules.Read:
                    break;
            }
        }

        public void SetSector(int sector)
        {
            Sector = sector;
        }

        public void SetID(int id)
        {
            ID = id;
        }

        public bool LogIn()
        {
            return UserInterface.Base.CheckLogin(Login, Password);
        }
    }
}
