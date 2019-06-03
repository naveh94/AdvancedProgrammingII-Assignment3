using System;
using System.Collections.Concurrent;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Net.Sockets;
using System.Text;
using System.Threading;
using System.Web;

namespace Ex3.Models.Network
{
    /// <summary>
    /// Created the whole Client class without using threads,
    /// because either we will manage the threads on anohter class, or we will keep it without
    /// concurrency. Either way we cannot do anything until the Client have connected.
    /// </summary>
    public class Client: IClient
    {
        private IPEndPoint _endPoint;
        private TcpClient _client;
        private NetworkStream _stream;
        private BinaryWriter _writer;
        private BinaryReader _reader;
        private Thread _clientThread;

        public Client(string ip, int port)
        {
           _endPoint = new IPEndPoint(IPAddress.Parse(ip), port);
            _client = new TcpClient();
            _clientThread = new Thread(() =>
            {
                while (!_client.Connected)
                {
                    try
                    {
                        _client.Connect(_endPoint);
                    }
                    catch (Exception) { };
                }
                _stream = _client.GetStream();
                _writer = new BinaryWriter(_stream);
                _reader = new BinaryReader(_stream);
            });

        }

        public void Connect()
        {
            _clientThread.Start();
        }
        
        public void Disconnect()
        {
            _clientThread.Abort();
            _writer.Close();
            _reader.Close();
            _stream.Close();
        }

        public string GetValue(string input)
        {
            string buffer = "";
            char c;
            while (_writer == null) { }
            _writer.Write(Encoding.ASCII.GetBytes(input));
            do
            {
                c = _reader.ReadChar();
                buffer += c;
            } while (c != '\n');
            return buffer;
        }
    }
}