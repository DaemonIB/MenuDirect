using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace MenuDirectTestSpike
{
    interface iSendable<T>
    {
        void SendToDB(T item);
        void DeleteitemProduct();
    }
}
