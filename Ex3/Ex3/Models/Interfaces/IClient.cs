using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ex3.Models.Interfaces
{
    interface IClient
    {
        string IP { get; set; }
        int Port { get; set; }

        void Connect();
        void Disconnect();
        string GetValue(string input);
    }
}
