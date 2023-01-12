using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Permissions;
using System.ServiceModel;
using System.Text;
using System.Threading.Tasks;

namespace Common
{
    [ServiceContract]
    public interface IServerTimer
    {
        [OperationContract]
        void pokreniTimer();

        [OperationContract]
        void zaustaviTimer();

        [OperationContract]
        void ponistiTimer();

        [OperationContract]
        void postaviTimer(int i);

        [OperationContract]
        int ocitajTimer();
    }
}
