using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Permissions;
using System.ServiceModel;
using System.Text;
using System.Threading.Tasks;

namespace IServis
{
    [ServiceContract]
    public interface IServerTimer
    {
        [OperationContract]
        void pokreniTimer(int i);

        [OperationContract]
        void zaustaviTimer(string s);

        [OperationContract]
        void ponistiTimer(string s);

        [OperationContract]
        void postaviTimer(string s);

        [OperationContract]
        void ocitajTimer(string s);
    }
}
