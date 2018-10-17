using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Net;
using System.Net.Sockets;

namespace Server1
{
    class Program
    {
        static void Main(string[] args)
        {
            //b1: Mo port
            UdpClient server = new UdpClient(9050);
            //b2: Trao doi du lieu
            IPEndPoint client = new IPEndPoint(IPAddress.Any, 0);
            byte[] data1 = new byte[10];
            data1 = server.Receive(ref client);
            string so1 = Encoding.ASCII.GetString(data1, 0, data1.Length);
            int a = int.Parse(so1);
            byte[] data2 = new byte[10];
            data2 = server.Receive(ref client);
            string so2 = Encoding.ASCII.GetString(data2, 0, data2.Length);
            int b = int.Parse(so2);          
            int kq = a + b;          
            byte[] data3 = new byte[10];
            data3=BitConverter.GetBytes(kq);
            //data3 = Encoding.ASCII.GetBytes(kq.ToString());
            server.Send(data3, data3.Length, client);
            //b3 Dong ket noi
            server.Close();
        }
    }
}
