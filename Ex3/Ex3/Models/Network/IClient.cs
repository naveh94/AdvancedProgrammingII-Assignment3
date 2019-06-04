using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ex3.Models.Network
{
    //client interface
    public interface IClient
    {
        void Connect();
        void Disconnect();
        string GetValue(string input);
    }
}
