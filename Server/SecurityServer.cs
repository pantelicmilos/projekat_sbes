using IServis;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Permissions;
using System.Text;
using System.Threading.Tasks;

namespace Server
{
    public class SecurityServer : IServerTimer
    {
        //[PrincipalPermission(SecurityAction.Demand, Role = "See")]
        public void ocitajTimer(string s)
        {
            throw new NotImplementedException();
        }

        public void pokreniTimer(int i)
        {
            int a = i + 2;
            Console.WriteLine($"Ispis server: {a}\n");
        }

        public void ponistiTimer(string s)
        {
            throw new NotImplementedException();
        }

        public void postaviTimer(string s)
        {
            throw new NotImplementedException();
        }

        public void zaustaviTimer(string s)
        {
            throw new NotImplementedException();
        }
    }
}
