using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StyleLibrary
{
    public interface IAccountManagment
    {
        void Deregistration();
        void Message(string login, string password);
        void RegWindowOpen();
    }
}
