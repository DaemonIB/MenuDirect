using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace AdminUI
{
    interface iSendable<T>
    {
        void SendToDB(T item);
        void DeleteitemProduct();
    }
}
